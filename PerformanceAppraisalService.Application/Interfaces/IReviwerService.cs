using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IReviwerService
    {
        Task<string> CreateReviwerAsync(ReviwerDto reviwerDto);
        Task<List<ReviwerDto>> GetReviwerListAsync();
        Task<ReviwerDto> GetReviwerByIdAsync(Guid id);
        Task<string> UpdateReviwerAsync(ReviwerDto reviwerDto);
        Task<string> DeleteReviwerAsync(Guid id);
    }
}
