using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IDepartmentCriteriaGroupService
    {

        Task<string> CreateDepartmentCriteriaGroupAsync(DepartmentCriteriaGroupDto departmentCriteriaGroupDto);
        Task<List<DepartmentCriteriaGroupDto>> GetCriteriaGroupByDepartmentAsync(Guid departmentId);

        Task<List<DepartmentCriteriaGroupDto>> GetDepartmentCriteria_groupAsync();
        Task<DepartmentCriteriaGroupDto> GetDepartmentCriteriaGroupByIdAsync(Guid id);
        Task<string> UpdateDepartmentCriteriaGroupAsync(DepartmentCriteriaGroupDto departmentCriteriaGroupDto);
        Task<string> DeleteDepartmentCriteriaGroupAsync(Guid id);

        Task<int> Totalweightages(Guid id);
    }
}
