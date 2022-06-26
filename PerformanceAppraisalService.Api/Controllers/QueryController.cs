using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerformanceAppraisalService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly IQueryService _queryService;
        public QueryController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        // api/query/employeecount

        // api/result/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _queryService.ShowCount();
            return Ok(result);
        }

        // api/query/marks?id=
        [HttpGet]
        [Route("marksbyreviwer")]
        public async Task<IActionResult> MarksList(Guid Id)
        {
            var result = await _queryService.GetRevieweemarks(Id);
            return Ok(result);
        }

        // api/query/marksbygroup?id=
        [HttpGet]
        [Route("marksbygroup")]
        public async Task<IActionResult> MarksListbygroup(Guid Id)
        {
            var result = await _queryService.GetRevieweemarksbyGroup(Id);
            return Ok(result);
        }

        // api/query/total?id=
        [HttpGet]
        [Route("total")]
        public async Task<IActionResult> Total(Guid Id)
        {
            var result = await _queryService.GetTotalmarksbyReviwee(Id);
            return Ok(result);
        }

        // api/query/totalby-departmentid?id=
        [HttpGet]
        [Route("totalby-departmentid")]
        public async Task<IActionResult> TotalbyDepartment(Guid Id)
        {
            var result = await _queryService.GetTotalGroupmarksbydepartment(Id);
            return Ok(result);
        }

        // api/query/noOfemployees
        [HttpGet]
        [Route("noOfemployees")]
        public async Task<IActionResult> NoOfEmployees()
        {
            var result = await _queryService.NoOfEmployees();
            return Ok(result);
        }

        // api/query/noOfdepartments
        [HttpGet]
        [Route("noOfdepartments")]
        public async Task<IActionResult> NoOfDepartments()
        {
            var result = await _queryService.NoOfDepartments();
            return Ok(result);
        }

        // api/query/noOfteams
        [HttpGet]
        [Route("noOfteams")]
        public async Task<IActionResult> NoOfTeams()
        {
            var result = await _queryService.NoOfTeams();
            return Ok(result);
        }


    }
}
