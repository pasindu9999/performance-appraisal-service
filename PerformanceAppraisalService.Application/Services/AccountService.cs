using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        public async Task<string> PostApplicationUser(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = applicationUserDto.Email,
                Email = applicationUserDto.Email,
                FullName = applicationUserDto.FullName
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
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString())
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
