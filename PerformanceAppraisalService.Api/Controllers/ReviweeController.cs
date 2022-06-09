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
    public class ReviweeController : ControllerBase
    {
        private readonly IReviweeService _reviweeService;

        public ReviweeController(IReviweeService reviweeService)
        {
            _reviweeService = reviweeService;
        }

        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ReviweeDto reviweeDto)
        {

            var response = await _reviweeService.CreateReviweeAsync(reviweeDto);

            return Ok(response);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _reviweeService.GetReviweeListAsync();
            return Ok(result);
        }

        
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> OrganizationById(Guid id)
        {
            var result = await _reviweeService.GetReviweeByIdAsync(id);
            return Ok(result);
        }

        
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(ReviweeDto reviweeDto)
        {
            var response = await _reviweeService.UpdateReviweeAsync(reviweeDto);
            return Ok(response);
        }

         
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _reviweeService.DeleteReviweeAsync(id);
            return Ok(response);
        }
    }
}
