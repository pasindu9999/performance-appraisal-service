using Azure.Storage.Queues;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Domain.Enum;
using PerformanceAppraisalService.Domain.Roles;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Services
{
    public class AccountService: IAccountService
    {
        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signInManager;

        private readonly ApplicationSettings _appSettings;

        private readonly IQueueService _queueService;

        private IConfiguration _configuration;


        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings, IQueueService queueService, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _queueService = queueService;
            _configuration = configuration;
        }

        public async Task<string> PostApplicationUser(ApplicationUserDto applicationUserDto)
        {
            applicationUserDto.Role = UserRoles.Admin;
            var applicationUser = new ApplicationUser()
            {
                UserName = applicationUserDto.Email,
                Email = applicationUserDto.Email,
                FullName = applicationUserDto.FullName,
            };
           
            try
            {
                var user = await _userManager.FindByNameAsync(applicationUserDto.Email);
                if (user != null)
                {
                    return "Duplicate Username";
                }
                else
                {
                    var result = await _userManager.CreateAsync(applicationUser, applicationUserDto.Password);
                    await _userManager.AddToRoleAsync(applicationUser, applicationUserDto.Role);
                    
                    await _queueService.SendToQueue(applicationUserDto.Email, EmailType.Registration, null);

                    if(result.Succeeded)
                    {

                        var user1 = await _userManager.FindByNameAsync(applicationUserDto.Email);

                        var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user1);
                        var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                        var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                        string url = $"{_configuration["AppUrl"]}/api/account/confirm-email?userid={user1.Id}&token={validEmailToken}";


                        await _queueService.SendToQueue(applicationUserDto.Email, EmailType.ConfirmEmail, url);
                        
                    }
                    


                    return "Registration successfull";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> LogIn(LogInDto logInDto)
        {
            var user = await _userManager.FindByNameAsync(logInDto.UserName);
            var response = await _signInManager.PasswordSignInAsync(logInDto.UserName,logInDto.Password,false,false);//3rd parameter userd for cookies, 4th parameter is used for if the user enter the password multiple times block access
            if (response.IsNotAllowed)
            {
                return "Not allowed to login";
            }
            else
            {
                if (user != null && await _userManager.CheckPasswordAsync(user, logInDto.Password))
                {

                    await _queueService.SendToQueue(logInDto.UserName, EmailType.LogIn, null);

                    //Get role assigned to the user
                    var role = await _userManager.GetRolesAsync(user);
                    IdentityOptions _options = new IdentityOptions();

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return token;
                }
                else
                    return "Username or password is incorrect";

            }

        }

        public async Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "User not found"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Email confirmed successfully!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                IsSuccess = false,
                Message = "Email did not confirm",
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<string> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
            {
                return "No user associated with email";
            }



            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}/ResetPassword?email={forgotPasswordDto.Email}&token={validToken}";

            await _queueService.SendToQueue(forgotPasswordDto.Email, EmailType.ForgotPassword, url);


            return "Reset password URL has been sent to the email successfully!";
        }

        public async Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            if (model.NewPassword != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Password doesn't match its confirmation",
                };

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);

            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Password has been reset successfully!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }

    }
}
