using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
   public interface ICriteria_GroupService
    {
        Task<string> Create_criteriaGroupAsync(Criteria_GroupDto criteria_groupDto);
        Task<List<Criteria_GroupDto>> GetCriteria_groupAsync();
        Task<Criteria_GroupDto> GetCriteria_GroupByIdAsync(Guid id);
        Task<object> UpdateCriteria_GroupAsync(Criteria_GroupDto criteria_groupDto);
        Task<object> DeleteCriteria_GroupAsync(Guid id);
    }
}
