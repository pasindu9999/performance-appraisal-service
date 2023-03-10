using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface ICriteria_Service
    {
        Task<string> Create_criteriaAsync(CriteriaDto criteriaDto);
        Task<List<CriteriaDto>> GetCriteriaAsync();
        Task<List<CriteriaDto>> GetCriteriabyCriteriaGroupAsync(Guid CriteriaGroupId);
        Task<CriteriaDto> GetCriteriaByIdAsync(Guid id);
        Task<string> UpdateCriteriaAsync(CriteriaDto criteriaDto);
        Task<object> DeleteCriteriaAsync(Guid id);

    }
}
