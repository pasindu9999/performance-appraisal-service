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
    public class ReviwerController : ControllerBase
    {
        private readonly IReviwerService _reviwerService;
        public ReviwerController(IReviwerService reviwerService)
        {
            _reviwerService = reviwerService;
        }

        // api/reviwer/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ReviwerDto reviwerDto)
        { 
           var response = await _reviwerService.CreateReviwerAsync(reviwerDto);
           return Ok(response);           
        }

        // api/reviwer/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _reviwerService.GetReviwerListAsync();
            return Ok(result);
        }

        // api/reviwer/by-id?id=
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> ReviwerById(Guid id)
        {
            var result = await _reviwerService.GetReviwerByIdAsync(id);
            return Ok(result);
        }

        // api/reviwer/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(ReviwerDto reviwerDto)
        {
            var response = await _reviwerService.UpdateReviwerAsync(reviwerDto);
            return Ok(response);
        }

        // api/reviwer/delete?id= 
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _reviwerService.DeleteReviwerAsync(id);
            return Ok(response);
        }
    }
}
