using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IPanelService
    {
        Task<string> CreatePanelAsync(PanelDto panelDto);
        Task<List<PanelDto>> GetPanelListAsync();
        Task<PanelDto> GetPanelByIdAsync(Guid id);
        Task<string> UpdatePanelAsync(PanelDto panelDto);
        Task<string> DeletePanelAsync(Guid id);
    }
}
