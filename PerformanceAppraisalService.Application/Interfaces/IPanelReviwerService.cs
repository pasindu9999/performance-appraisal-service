using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IPanelReviwerService
    {
        Task<string> CreatePanelReviwerAsync(PanelReviwerDto panelReviwerDto);
        Task<List<PanelReviwerDto>> GetGetReviwerByPanelAsync(Guid panelId);
        Task<PanelReviwerDto> GetPanelReviwerByIdAsync(Guid id);
        Task<string> UpdatePanelReviwerAsync(PanelReviwerDto panelReviwerDto);
        Task<string> DeletePanelReviwerAsync(Guid pid , Guid rid);
    }
}
