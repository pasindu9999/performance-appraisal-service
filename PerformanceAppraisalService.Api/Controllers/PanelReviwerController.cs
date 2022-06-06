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
    public class PanelReviwerController : ControllerBase
    {
        private readonly IPanelReviwerService _panelReviwerService;

        public PanelReviwerController(IPanelReviwerService panelReviwerService)
        {
            _panelReviwerService = panelReviwerService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(PanelReviwerDto panelDto)
        {
            var response = await _panelReviwerService.CreatePanelReviwerAsync(panelDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("by-panelId")]
        public async Task<IActionResult> List(Guid panelId)
        {
            var result = await _panelReviwerService.GetGetReviwerByPanelAsync(panelId);
            return Ok(result);
        }

        /*
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _panelReviwerService.DeletePanelReviwerAsync(id);
            return Ok(response);
        }
        */
    }
}
