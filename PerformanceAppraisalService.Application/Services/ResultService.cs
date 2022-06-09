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

        public Task<object> DeleteResultAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultDto>> GetResultbyPanelAsync(Guid PanelId, Guid ReviwerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultDto>> GetResultListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateResultAsync(TeamDto teamDto)
        {
            throw new NotImplementedException();
        }
    }
}
