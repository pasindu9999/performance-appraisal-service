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
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        
        public OrganizationController(IOrganizationService organizationService)
        {
            
            _organizationService = organizationService;
        }

        // api/organization/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(OrganizationDto organizationDto)
        {
            var response = await _organizationService.CreateOrganizationAsync(organizationDto);
            return Ok(response);
        }
                    

        // api/organization/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _organizationService.GetOrganizationListAsync();
            return Ok(result);
        }
        
        // api/organization/by-id?id=
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> OrganizationById(Guid id)
        {
            var result = await _organizationService.GetOrganizationByIdAsync(id);
            return Ok(result);
        }
        
        // api/organization/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(OrganizationDto organizationDto)
        {
            var response = await _organizationService.UpdateOrganizationAsync(organizationDto);
            return Ok(response);
        }
        
        // api/organization/delete?id= 
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _organizationService.DeleteOrganizationAsync(id);
            return Ok(response);
        }
    }
}