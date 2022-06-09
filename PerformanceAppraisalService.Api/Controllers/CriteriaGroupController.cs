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
    public class Criteria_GroupController : ControllerBase
    {
        private readonly ICriteria_GroupService _criteria_GroupService;
        public Criteria_GroupController(ICriteria_GroupService criteria_GroupService)
        {
            _criteria_GroupService = criteria_GroupService;
        }

        // api/organization/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(Criteria_GroupDto criteria_groupDto)
        {
            var response = await _criteria_GroupService.Create_criteriaGroupAsync(criteria_groupDto);
            return Ok(response);
        }

        // api/organization/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _criteria_GroupService.GetCriteria_groupAsync();
            return Ok(result);
        }

        // api/organization/by-id?id=
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> PA_sheetById(Guid id)
        {
            var result = await _criteria_GroupService.GetCriteria_GroupByIdAsync(id);
            return Ok(result);
        }

        // api/organization/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(Criteria_GroupDto criteria_groupDto)
        {
            var response = await _criteria_GroupService.UpdateCriteria_GroupAsync(criteria_groupDto);
            return Ok(response);
        }

        // api/organization/delete?id=
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _criteria_GroupService.DeleteCriteria_GroupAsync(id);
            return Ok(response);
        }
    }
}
