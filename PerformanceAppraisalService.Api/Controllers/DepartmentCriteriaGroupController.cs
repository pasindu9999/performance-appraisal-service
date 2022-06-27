using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentCriteriaGroupController : ControllerBase
    {
        private readonly IDepartmentCriteriaGroupService _departmentCriteriaGroupService;

        public DepartmentCriteriaGroupController(IDepartmentCriteriaGroupService departmentCriteriaGroupService)
        {
            _departmentCriteriaGroupService = departmentCriteriaGroupService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(DepartmentCriteriaGroupDto departmentCriteriaGroupDto)
        {
            var response = await _departmentCriteriaGroupService.CreateDepartmentCriteriaGroupAsync(departmentCriteriaGroupDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _departmentCriteriaGroupService.GetDepartmentCriteria_groupAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("by-departmentId")]
        public async Task<IActionResult> List(Guid departmentId)
        {
            var result = await _departmentCriteriaGroupService.GetCriteriaGroupByDepartmentAsync(departmentId);
            return Ok(result);
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _departmentCriteriaGroupService.DeleteDepartmentCriteriaGroupAsync(id);
            return Ok(response);
        }

    }
}
