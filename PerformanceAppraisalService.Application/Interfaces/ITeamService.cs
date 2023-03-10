using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PerformanceAppraisalService.Application.Dtos;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface ITeamService
    {
        Task<string> CreateTeamAsync(TeamDto teamDto);
        Task<List<TeamDto>> GetTeamListAsync();
        Task<List<TeamDto>> GetTeamsbyDepartmentAsync(Guid DepartmentId);
        Task<TeamDto> GetTeamByIdAsync(Guid id);
        Task<string> UpdateTeamAsync(TeamDto teamDto);
        Task<string> DeleteTeamAsync(Guid id);
    }
}
