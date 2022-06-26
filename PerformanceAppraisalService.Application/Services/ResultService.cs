using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace PerformanceAppraisalService.Application.Services
{
    public class ResultService : IResultService
    {
        private readonly ApplicationDbContext _context;

        public ResultService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateResultAsync(ResultDto resultDto)
        {
            var result = new Result
            {
                CriteriaId = resultDto.CriteriaId,
                ReviwerId = resultDto.ReviwerId,
                ReviweeId = resultDto.ReviweeId,
                Marks = resultDto.Marks
            };


            _context.Add(result);
            await _context.SaveChangesAsync();

            return "Result stored...!";
        }

        public async Task<object> DeleteResultAsync(Guid id)
        {
            var result = await _context.Results.FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }

        public async Task<List<ResultDto>> GetResultListAsync()
        {
            var resultList = await _context.Results
                .Select(x => new ResultDto
                {
                    Id = x.Id,
                    CriteriaId = x.CriteriaId,
                    ReviwerId = (Guid)x.ReviwerId,
                    ReviweeId = (Guid)x.ReviweeId,
                    Marks = (int)x.Marks,
                })
                .ToListAsync();

            return resultList;
        }

        public async Task<ResultDto> GetResultByIdAsync(Guid id)
        {
            var result = await _context.Results
                .Select(x => new ResultDto
                {
                    Id = x.Id,
                    CriteriaId = x.CriteriaId,
                    ReviwerId = (Guid)x.ReviwerId,
                    ReviweeId = (Guid)x.ReviweeId,
                    Marks = (int)x.Marks,
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public Task<List<ResultDto>> GetResultbyReviwerAsync(Guid ReviwerId)
        {
            var resultList = _context.Results.Where(x=>x.ReviwerId == ReviwerId)
                .Select(x => new ResultDto
                {
                    Id = x.Id,
                    CriteriaId = x.CriteriaId,
                    ReviwerId = (Guid)x.ReviwerId,
                    ReviweeId = (Guid)x.ReviweeId,
                    Marks = (int)x.Marks,
                })
                .ToListAsync();

            return resultList;
        }

        public Task<List<ResultDto>> GetResultbyReviweeAsync(Guid ReviweeId)
        {
            var resultList = _context.Results.Where(x => x.ReviweeId == ReviweeId)
                .Select(x => new ResultDto
                {
                    Id = x.Id,
                    CriteriaId = x.CriteriaId,
                    ReviwerId = (Guid)x.ReviwerId,
                    ReviweeId = (Guid)x.ReviweeId,
                    Marks = (int)x.Marks,
                })
                .ToListAsync();

            return resultList;
        }

        public async Task<string> UpdateResultAsync(ResultDto resultDto)
        {
            var results = await _context.Results.FirstOrDefaultAsync(x => x.Id == resultDto.Id);

            if (results.Id != null)
            {
                results.CriteriaId = resultDto.CriteriaId;
                results.ReviwerId = resultDto.ReviwerId;
                results.ReviweeId = resultDto.ReviweeId;
                results.Marks = resultDto.Marks;

                await _context.SaveChangesAsync();
                return "Result update success...!";
            }

            return "Result not update...!";
        }
    }
}
