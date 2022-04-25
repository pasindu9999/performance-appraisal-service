using Create_PA.application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Create_PA.application.Interfaces
{
    public interface IPA_sheetService
    {
        Task<string> CreatePA_sheetAsync(PA_sheet_Dto pa_sheet_Dto);
        Task<List<PA_sheet_Dto>> GetPA_sheetListAsync();
        Task<PA_sheet_Dto> GetPA_sheetByIdAsync(Guid id);
        Task<object> UpdatePA_sheetAsync(PA_sheet_Dto pa_sheet_Dto);
        Task<object> DeletePA_sheetAsync(Guid id);
    }
}
