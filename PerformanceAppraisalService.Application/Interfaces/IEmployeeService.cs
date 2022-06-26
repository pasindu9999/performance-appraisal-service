using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<string> CreateEmployeeAsync(EmployeeDto employeeDto);
        Task<List<EmployeeDto>> GetEmployeeListAsync();
        Task<List<EmployeeDto>> GetEmployeesbyDepartmentAsync(Guid DepartmentId);
        Task<List<EmployeeDto>> GetEmployeesbyTeamAsync(Guid TeamId);
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<string> UpdateEmployeeAsync(EmployeeDto employeeDto);
        Task<string> DeleteEmployeeAsync(Guid id);

  
    }
}
