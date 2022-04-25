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
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationService _designationService;
        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
        }

        // api/designation/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(DesignationDto designationDto)
        {
            var response = await _designationService.CreateDesignationAsync(designationDto);
            return Ok(response);
        }

        // api/designation/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _designationService.GetDesignationListAsync();
            return Ok(result);
        }

        // api/designation/by-id?id=
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> DesignationById(Guid id)
        {
            var result = await _designationService.GetDesignationByIdAsync(id);
            return Ok(result);
        }

        // api/designation/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(DesignationDto designationDto)
        {
            var response = await _designationService.UpdateDesignationAsync(designationDto);
            return Ok(response);
        }

        // api/designation/delete?id=
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _designationService.DeleteDesignationAsync(id);
            return Ok(response);
        }
    }
}
