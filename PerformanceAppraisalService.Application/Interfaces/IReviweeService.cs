using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IReviweeService
    {
        Task<string> CreateReviweeAsync(ReviweeDto reviweeDto);
        Task<List<ReviweeDto>> GetReviweeListAsync();
        Task<ReviweeDto> GetReviweeByIdAsync(Guid id);
        Task<string> UpdateReviweeAsync(ReviweeDto reviweeDto);
        Task<string> DeleteReviweeAsync(Guid id);
    }
}
