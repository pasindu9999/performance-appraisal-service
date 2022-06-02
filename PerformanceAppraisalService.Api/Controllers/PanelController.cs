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
            
            return Ok();
        }
    }
}
