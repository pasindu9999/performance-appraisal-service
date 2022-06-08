using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Application.Dtos;

namespace PerformanceAppraisalService.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PAsheetController : ControllerBase
    {
        private readonly IPAsheetService _pasheetService;
        public PAsheetController(IPAsheetService pa_sheetService)
        {
            _pasheetService = pa_sheetService;
        }

        // api/organization/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(PAsheetDto pa_sheet_Dto)
        {
            var response = await _pasheetService.CreatePAsheetAsync(pa_sheet_Dto);
            return Ok(response);
        }

        // api/organization/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _pasheetService.GetPAsheetListAsync();
            return Ok(result);
        }

        // api/organization/by-id?id=
        [HttpGet]
        [Route("by-id")]
        public async Task<IActionResult> PA_sheetById(Guid id)
        {
            var result = await _pasheetService.GetPAsheetByIdAsync(id);
            return Ok(result);
        }

        // api/organization/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(PAsheetDto pa_sheet_Dto)
        {
            var response = await _pasheetService.UpdatePAsheetAsync(pa_sheet_Dto);
            return Ok(response);
        }

        // api/organization/delete?id=
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _pasheetService.DeletePAsheetAsync(id);
            return Ok(response);
        }

    }
}
