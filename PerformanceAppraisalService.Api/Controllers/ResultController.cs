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
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;
        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }

        // api/result/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ResultDto resultDto)
        {
            var response = await _resultService.CreateResultAsync(resultDto);
            return Ok(response);
        }

        // api/result/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _resultService.GetResultListAsync();
            return Ok(result);
        }

        //api/result/by-reviwerid?reviwerid=
        [HttpGet]
        [Route("by-reviwerid")]
        public async Task<IActionResult> reviwerList(Guid reviwerId)
        {
            var result = await _resultService.GetResultbyReviwerAsync(reviwerId);
            return Ok(result);
        }

        //api/result/by-reviweeid?reviweeid=
        [HttpGet]
        [Route("by-reviweeid")]
        public async Task<IActionResult> reviweeList(Guid reviweeId)
        {
            var result = await _resultService.GetResultbyReviwerAsync(reviweeId);
            return Ok(result);
        }

        // api/result/by-id?id=
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> ResultById(Guid id)
        {
            var result = await _resultService.GetResultByIdAsync(id);
            return Ok(result);
        }

        // api/result/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(ResultDto resultDto)
        {
            var response = await _resultService.UpdateResultAsync(resultDto);
            return Ok(response);
        }

        // api/result/delete?id=
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete (Guid id)
        {
            {
                var response = await _resultService.DeleteResultAsync(id);
                return Ok(response);
            }
        }
    }
}