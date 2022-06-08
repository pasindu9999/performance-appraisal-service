using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IResultService
    {
        Task<string> CreateResultAsync(ResultDto ResultDto);
        Task<List<ResultDto>> GetResultListAsync();
        Task<List<ResultDto>> GetResultbyPanelAsync(Guid PanelId, Guid ReviwerId);
       // Task<TeamDto> GetTeamByIdAsync(Guid id);
        Task<string> UpdateResultAsync(TeamDto teamDto);
        Task<object> DeleteResultAsync(Guid id);
    }
}
