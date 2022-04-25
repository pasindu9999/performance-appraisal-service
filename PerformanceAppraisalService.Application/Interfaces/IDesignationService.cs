using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IDesignationService
    {
        Task<string> CreateDesignationAsync(DesignationDto designationDto);
        Task<List<DesignationDto>> GetDesignationListAsync();
        Task<DesignationDto> GetDesignationByIdAsync(Guid id);
        Task<string> UpdateDesignationAsync(DesignationDto designationDto);
        Task<object> DeleteDesignationAsync(Guid id);
    }
}
