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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // api/employee/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(EmployeeDto employeeDto)
        {
            var response = await _employeeService.CreateEmployeeAsync(employeeDto);
            return Ok(response);
        }

        // api/employee/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _employeeService.GetEmployeeListAsync();
            return Ok(result);
        }

        // api/employee/by-id?id=
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> EmployeeById(Guid id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(result);
        }

        // api/employee/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(EmployeeDto employeeDto)
        {
            var response = await _employeeService.UpdateEmployeeAsync(employeeDto);
            return Ok(response);
        }

        // api/employee/delete?id=
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _employeeService.DeleteEmployeeAsync(id);
            return Ok(response);
        }
    }
}
