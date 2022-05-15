using Azure.Storage.Queues;
using Microsoft.AspNetCore.Identity;
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

        private readonly QueueStorageString _queueStorageString;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings, IOptions<QueueStorageString> queueStorageString)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _queueStorageString = queueStorageString.Value;
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

                    try
                    {
                        var client = new QueueClient(_queueStorageString.QueueClientString, "email-queue");

                        var user1 = await _userManager.FindByNameAsync(applicationUserDto.Email);

                        EmailQueueDto e = new EmailQueueDto();
                        e.UserId = new Guid(user1.Id);
                        e.EmailType = EmailType.Registration;

                        var jsonString = JsonConvert.SerializeObject(e);

                        string encodedStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonString));

                        await client.SendMessageAsync(encodedStr);
                    }
                    catch(Exception e)
                    {
                        return "Exception Occured " + e;
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
            if (user != null && await _userManager.CheckPasswordAsync(user, logInDto.Password))
            {

                try
                {
                    var client = new QueueClient(_queueStorageString.QueueClientString, "email-queue");

                    EmailQueueDto e = new EmailQueueDto();
                    e.UserId = new Guid(user.Id);
                    e.EmailType = EmailType.LogIn;

                    var jsonString = JsonConvert.SerializeObject(e);

                    string encodedStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonString));

                    await client.SendMessageAsync(encodedStr);
                }
                catch (Exception e)
                {
                    return "Exception Occured " + e;
                }

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
}
