using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface ICriteria_Service
    {
        Task<string> Create_criteriaGroupAsync(CriteriaDto criteriaDto);
        Task<List<CriteriaDto>> GetCriteriaAsync();
        Task<CriteriaDto> GetCriteriaByIdAsync(Guid id);
        Task<string> UpdateCriteriaAsync(CriteriaDto criteriaDto);
        Task<string> DeleteCriteriaAsync(Guid id);

    }
}
