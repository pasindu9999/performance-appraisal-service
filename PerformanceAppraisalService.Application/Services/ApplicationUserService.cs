using Microsoft.AspNetCore.Identity;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Services
{
    public class ApplicationUserService: IApplicationUserService
    {
        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<object> PostApplicationUser(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = applicationUserDto.UserName,
                Email = applicationUserDto.Email,
                FullName = applicationUserDto.FullName
            };
           
            try
            {
                var result = await _userManager.CreateAsync(applicationUser, applicationUserDto.Password);
                return 1;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
