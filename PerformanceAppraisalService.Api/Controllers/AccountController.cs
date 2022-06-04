using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        private IConfiguration _configuration;

        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Create(ApplicationUserDto applicationUserDto)
        {
            var response = await _accountService.PostApplicationUser(applicationUserDto);
            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Create(LogInDto logInDto)
        {
            var response = await _accountService.LogIn(logInDto);
            return Ok(response);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
                return NotFound();

            var result = await _accountService.ConfirmEmailAsync(userId, token);

            if (result.IsSuccess)
            {
                return Redirect($"{_configuration["ClientAppUrl"]}/confirmemail");
            }
            else
            {
                return Redirect($"{_configuration["ClientAppUrl"]}/verificationfail");
            }


        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            if (string.IsNullOrEmpty(forgotPasswordDto.Email))
                return NotFound();

            var result = await _accountService.ForgotPasswordAsync(forgotPasswordDto);
            return Ok(result); 

        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var result = await _accountService.ResetPasswordAsync(model);
            return Ok(result);
        }


    }
}
