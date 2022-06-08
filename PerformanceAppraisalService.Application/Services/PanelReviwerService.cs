using Microsoft.EntityFrameworkCore;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Services
{
    

    public class PanelReviwerService : IPanelReviwerService
    {
        private readonly ApplicationDbContext _context;

        public PanelReviwerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreatePanelReviwerAsync(PanelReviwerDto panelDto)
        {
            var panel = new PanelReviwer
            {
                PanelId = panelDto.PanelId,
                //ReviwerId = panelDto.ReviwerId,
                CreateDate = panelDto.CreateDate
            };


            _context.Add(panel);
            await _context.SaveChangesAsync();

            return "Organization Create success...!";
        }

        public async Task<string> DeletePanelReviwerAsync(Guid pid , Guid rid)
        {
            var reviwee = await _context.PanelReviwers.FirstOrDefaultAsync(x => x.PanelId == pid);

            if (reviwee != null)
            {
                _context.Remove(reviwee);
                await _context.SaveChangesAsync();
                return "Reviwee deleted successfully";
            }

            return "Reviwee deleted failed";
        }

        public Task<PanelReviwerDto> GetPanelReviwerByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PanelReviwerDto>> GetGetReviwerByPanelAsync(Guid panelId)
        {
            var reviwerList = await _context.PanelReviwers.Where(x=>x.PanelId == panelId)
                .Select(x => new PanelReviwerDto
                {
                    PanelId = x.PanelId,
                   // ReviwerId = x.ReviwerId
                })
                .ToListAsync();

            return reviwerList;
        }

        public Task<string> UpdatePanelReviwerAsync(PanelReviwerDto panelReviwerDto)
        {
            throw new NotImplementedException();
        }
    }
}
