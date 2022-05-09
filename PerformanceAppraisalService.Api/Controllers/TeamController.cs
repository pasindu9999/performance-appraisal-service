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
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // api/team/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(TeamDto teamDto)
        {
            var response = await _teamService.CreateTeamAsync(teamDto);
            return Ok(response);
        }


        // api/team/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List(Guid DepartmentId)
        {
            var result = await _teamService.GetTeamsAsync(DepartmentId);
            return Ok(result);
        }

        // api/team/by-id?id=
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> TeamById(Guid id)
        {
            var result = await _teamService.GetTeamByIdAsync(id);
            return Ok(result);
        }

        // api/team/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(TeamDto teamDto)
        {
            var response = await _teamService.UpdateTeamAsync(teamDto);
            return Ok(response);
        }

        // api/team/delete?id=
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _teamService.DeleteTeamAsync(id);
            return Ok(response);
        }
    }
}
