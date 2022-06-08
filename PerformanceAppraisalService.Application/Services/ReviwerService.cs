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
    public class ReviwerService : IReviwerService
    {
        private readonly ApplicationDbContext _context;

        public ReviwerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateReviwerAsync(ReviwerDto reviwerDto)
        {
            var reviwer = new Reviwer
            {
                EmployeeId = reviwerDto.EmployeeId,
                PanelId = reviwerDto.PanelId
            };


            _context.Add(reviwer);
            await _context.SaveChangesAsync();

            return "Reviwer added successfully...!";
        }

        public async Task<string> DeleteReviwerAsync(Guid id)
        {
            var reviwer = await _context.Reviwers.FirstOrDefaultAsync(x => x.Id == id);

            if (reviwer != null)
            {
                _context.Remove(reviwer);
                await _context.SaveChangesAsync();
                return "Reviwer deleted successfully";
            }

            return "Reviwer not deleted...";
        }

        public async Task<ReviwerDto> GetReviwerByIdAsync(Guid id)
        {
            var reviwer = await _context.Reviwers.Include(x => x.Employee)
                .Select(x => new ReviwerDto
                {
                    Id = x.Id,
                    EmployeeId = x.EmployeeId,
                    PanelId = x.PanelId
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return reviwer;
        }

        public async Task<List<ReviwerDto>> GetReviwerListAsync()
        {
            var reviwersList = await _context.Reviwers.Include(x => x.Employee)
                .Select(x => new ReviwerDto
                {
                    Id = x.Id,
                    EmployeeId = x.EmployeeId,
                    PanelId = x.PanelId,
                    
                })
                .ToListAsync();

            return reviwersList;
        }

        public async Task<string> UpdateReviwerAsync(ReviwerDto reviwerDto)
        {
            var reviwer = await _context.Reviwers.FirstOrDefaultAsync(x => x.Id == reviwerDto.Id);

            if (reviwer != null)
            {

                reviwer.EmployeeId = reviwerDto.EmployeeId;
                reviwer.PanelId = reviwerDto.PanelId;

                await _context.SaveChangesAsync();
                return "Reviwer updated successfully";
            }

            return "Reviwer not updated..";
        }
    }
}
