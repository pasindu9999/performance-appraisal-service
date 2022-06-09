using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IPAsheetService
    {
        Task<string> CreatePAsheetAsync(PAsheetDto pasheet_Dto);
        Task<List<PAsheetDto>> GetPAsheetListAsync();
        Task<PAsheetDto> GetPAsheetByIdAsync(Guid id);
        Task<object> UpdatePAsheetAsync(PAsheetDto pa_sheet_Dto);
        Task<object> DeletePAsheetAsync(Guid id);
    }
}
