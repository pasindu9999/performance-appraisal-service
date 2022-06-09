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
    public class PanelController : ControllerBase
    {
        private readonly IPanelService _panelService;

        public PanelController(IPanelService panelService)
        {
            _panelService = panelService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(PanelDto panelDto)
        {
            var response = await _panelService.CreatePanelAsync(panelDto);
            return Ok(response);
        }

        // api/panel/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _panelService.GetPanelListAsync();
            return Ok(result);
        }

        // api/panel/by-id?id=
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> PanelById(Guid id)
        {
            var result = await _panelService.GetPanelByIdAsync(id);
            return Ok(result);
        }

        // api/panel/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(PanelDto panelDto)
        {
            var response = await _panelService.UpdatePanelAsync(panelDto);
            return Ok(response);
        }

        // api/panel/delete?id= 
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _panelService.DeletePanelAsync(id);
            return Ok(response);
        }
    }
}
