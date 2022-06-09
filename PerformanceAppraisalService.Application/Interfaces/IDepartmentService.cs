using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PerformanceAppraisalService.Application.Dtos;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<string> CreateDepartmentAsync(DepartmentDto departmentDto);
        Task<List<DepartmentDto>> GetDepartmentListAsync();
        Task<DepartmentDto> GetDepartmentByIdAsync(Guid id);
        Task<string> UpdateDepartmentAsync(DepartmentDto departmentDto);
        Task<string> DeleteDepartmentAsync(Guid id);
    }
}
