using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        private readonly IUserProfileService _userProfileService;
        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var response = await _userProfileService.GetUserProfile(userId);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("ForAdmin")]
        public async Task<IActionResult> GetAdmin()
        {
            var response = await _userProfileService.GetForAdmin();
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Senior_Developer")]
        [Route("ForSenior_Developer")]
        public async Task<IActionResult> GetEmployee()
        {
            var response = await _userProfileService.GetForEmployee();
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        [Route("ForAdminOrEmployee")]
        public async Task<IActionResult> GetAdminEmployee()
        {
            var response = await _userProfileService.GetForAdminOrEmployee();
            return Ok(response);
        }
    }
}
