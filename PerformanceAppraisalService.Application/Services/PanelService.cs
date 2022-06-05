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

        public async Task<PanelDto> GetPanelByIdAsync(Guid id)
        {
            var panel = await _context.Reviwers
                .Select(x => new PanelDto
                {
                    Id = x.Id
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return panel;
        }

        public async Task<List<PanelDto>> GetPanelListAsync()
        {
            var panelList = await _context.Panels
                .Select(x => new PanelDto
                {
                    Id = x.Id,
                    PanelNumber = x.PanelNumber
                })
                .ToListAsync();

            return panelList;
        }

        public Task<string> UpdatePanelAsync(PanelDto panelDto)
        {
            throw new NotImplementedException();
        }
    }
}
