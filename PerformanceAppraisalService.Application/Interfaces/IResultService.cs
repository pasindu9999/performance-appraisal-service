using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IResultService
    {
        Task<string> CreateResultAsync(ResultDto ResultDto);
        Task<List<ResultDto>> GetResultListAsync();
        Task<List<ResultDto>> GetResultbyReviwerAsync(Guid ReviwerId);
        Task<List<ResultDto>> GetResultbyReviweeAsync(Guid ReviweeId);
        Task<ResultDto> GetResultByIdAsync(Guid id);
        Task<string> UpdateResultAsync(ResultDto resultDto);
        Task<object> DeleteResultAsync(Guid id);
    }
}
