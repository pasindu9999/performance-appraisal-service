using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;

namespace PerformanceAppraisalService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // api/department/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(DepartmentDto departmentDto)
        {
            var response = await _departmentService.CreateDepartmentAsync(departmentDto);
            return Ok(response);
        }



        // api/department/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List2()
        {
            var result = await _departmentService.GetDepartmentListAsync();
            return Ok(result);
        }

        // api/department/by-id?id=
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> DepartmentById(Guid id)
        {
            var result = await _departmentService.GetDepartmentByIdAsync(id);
            return Ok(result);
        }

        // api/department/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(DepartmentDto departmentDto)
        {
            var response = await _departmentService.UpdateDepartmentAsync(departmentDto);
            return Ok(response);
        }

        // api/department/delete?id=
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _departmentService.DeleteDepartmentAsync(id);
            return Ok(response);
        }
    }
}
