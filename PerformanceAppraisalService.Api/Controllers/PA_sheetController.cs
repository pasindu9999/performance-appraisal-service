using Create_PA.application.Dtos;
using Create_PA.application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_PA.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PA_sheetController : ControllerBase
    {
        private readonly IPA_sheetService _pa_sheetService;
        public PA_sheetController(IPA_sheetService pa_sheetService)
        {
            _pa_sheetService = pa_sheetService;
        }

        // api/organization/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(PA_sheet_Dto pa_sheet_Dto)
        {
            var response = await _pa_sheetService.CreatePA_sheetAsync(pa_sheet_Dto);
            return Ok(response);
        }

        // api/organization/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var result = await _pa_sheetService.GetPA_sheetListAsync();
            return Ok(result);
        }

        // api/organization/by-id?id=
        [HttpGet]
        [Route("by/{id}")]
        public async Task<IActionResult> PA_sheetById(Guid id)
        {
            var result = await _pa_sheetService.GetPA_sheetByIdAsync(id);
            return Ok(result);
        }

        // api/organization/update
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(PA_sheet_Dto pa_sheet_Dto)
        {
            var response = await _pa_sheetService.UpdatePA_sheetAsync(pa_sheet_Dto);
            return Ok(response);
        }

        // api/organization/delete?id=
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _pa_sheetService.DeletePA_sheetAsync(id);
            return Ok(response);
        }

    }
}
