using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface ISalaryService
    {
        Task<string> CreateSalaryAsync(SalaryDto salaryDto);
        Task<List<SalaryDto>> GetSalaryListAsync();
        Task<SalaryDto> GetSalaryByIdAsync(Guid id);
        Task<string> UpdateSalaryAsync(SalaryDto salaryDto);
        Task<object> DeleteSalaryAsync(Guid id);
    }
}
