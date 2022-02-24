using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class LogInController : ControllerBase
    {

        private readonly ILogInService _logInService;
        public LogInController(ILogInService logInService)
        {
            _logInService = logInService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Create(LogInDto logInDto)
        {
            var response = await _logInService.LogIn(logInDto);
            return Ok(response);
        }
    }
}
