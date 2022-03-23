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
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;
        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        // api/salary/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(SalaryDto salaryDto)
        {
            var response = await _salaryService.CreateSalaryAsync(salaryDto);
            return Ok(response);
        }

        // api/designation/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _salaryService.GetSalaryListAsync();
            return Ok(result);
        }

        // api/salary/by-id?id=
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> SalaryById(Guid id)
        {
            var result = await _salaryService.GetSalaryByIdAsync(id);
            return Ok(result);
        }

        // api/salary/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(SalaryDto salaryDto)
        {
            var response = await _salaryService.UpdateSalaryAsync(salaryDto);
            return Ok(response);
        }

        // api/salary/delete?id=
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _salaryService.DeleteSalaryAsync(id);
            return Ok(response);
        }
    }
}
