using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Services
{
    public class PanelService : IPanelService
    {
        private readonly ApplicationDbContext _context;

        public PanelService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreatePanelAsync(PanelDto panelDto)
        {
            var panel = new Panel
            {
                //Reviwees = panelDto.Reviwees,
                //PanelReviwers = panelDto.PanelReviwers
            };


            _context.Add(panel);
            await _context.SaveChangesAsync();

            return "Organization Create success...!";
        }

        public Task<string> DeletePanelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PanelDto> GetPanelByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PanelDto>> GetPanelListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdatePanelAsync(PanelDto panelDto)
        {
            throw new NotImplementedException();
        }
    }
}
