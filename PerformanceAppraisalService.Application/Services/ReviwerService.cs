using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Services
{
    public class ReviwerService : IReviwerService
    {
        public Task<string> CreateReviwerAsync(ReviwerDto reviwerDto)
        {
            throw new NotImplementedException();
        }

        public Task<object> DeleteReviwerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ReviwerDto> GetReviwerByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReviwerDto>> GetReviwerListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateReviwerAsync(ReviwerDto reviwerDto)
        {
            throw new NotImplementedException();
        }
    }
}
