using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Services
{
    
    public class UserProfileService : IUserProfileService
    {

        private UserManager<ApplicationUser> _userManager;

        public UserProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

        }
       
        /*public async Task<List<string>> GetUserProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            List<string> myList = new List<string>
            {
                user.FullName,
                user.UserName
            };
            return myList;
        }*/

        public async Task<UserProfileDto> GetUserProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            UserProfileDto x = new UserProfileDto();
            x.FullName = user.FullName;
            x.UserName = user.UserName;
            return x;
        }

        public Task<string> GetForAdmin()
        {
            return Task.FromResult("Web Method For Admin");
        }

        public Task<string> GetForEmployee()
        {
            return Task.FromResult("Web Method For Employee");
        }

        public Task<string> GetForAdminOrEmployee()
        {
            return Task.FromResult("Web Method For Admin or Employee");
        }
    }
}

