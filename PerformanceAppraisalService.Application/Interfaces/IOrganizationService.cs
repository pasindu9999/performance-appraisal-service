using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PerformanceAppraisalService.Application.Dtos;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IOrganizationService
    {
        Task<string> CreateOrganizationAsync(OrganizationDto organizationDto);
        Task<List<OrganizationDto>> GetOrganizationListAsync();
        Task<OrganizationDto> GetOrganizationByIdAsync(Guid id);
        Task<object> UpdateOrganizationAsync(OrganizationDto organizationDto);
        Task<object> DeleteOrganizationAsync(Guid id);
    }
}