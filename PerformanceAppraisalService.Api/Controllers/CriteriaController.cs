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
    public class CriteriaController : ControllerBase
    {
        private readonly ICriteria_Service _criteriaService;
        public CriteriaController(ICriteria_Service criteria_Service)
        {
            _criteriaService = criteria_Service;
        }

        // api/organization/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CriteriaDto criteria_Dto)
        {
            var response = await _criteriaService.Create_criteriaAsync(criteria_Dto);
            return Ok(response);
        }

        // api/organization/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _criteriaService.GetCriteriaAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("by-criteriagroupid")]
        public async Task<IActionResult> List(Guid criteria_GroupID)
        {
            var result = await _criteriaService.GetCriteriabyGroupAsync(criteria_GroupID);
            return Ok(result);
        }

        // api/organization/by-id?id=
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> CriteriaById(Guid id)
        {
            var result = await _criteriaService.GetCriteriaByIdAsync(id);
            return Ok(result);
        }

        // api/organization/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(CriteriaDto criteriaDto)
        {
            var response = await _criteriaService.UpdateCriteriaAsync(criteriaDto);
            return Ok(response);
        }

        // api/organization/delete?id=
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _criteriaService.DeleteCriteriaAsync(id);
            return Ok(response);
        }
    }
}
