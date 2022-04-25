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
    public class DesignationService: IDesignationService
    {
        private readonly ApplicationDbContext _context;

        public DesignationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateDesignationAsync(DesignationDto designationDto)
        {
            var designation = new Designation
            {
                Name = designationDto.Name,
                Description = designationDto.Description,
            };

            _context.Add(designation);
            await _context.SaveChangesAsync();

            return "Designation Create success...!";
        }

        public async Task<List<DesignationDto>> GetDesignationListAsync()
        {
            var designationsList = await _context.Designations
                .Select(x => new DesignationDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                })
                .ToListAsync();

            return designationsList;
        }

        public async Task<DesignationDto> GetDesignationByIdAsync(Guid id)
        {
            var designation = await _context.Designations
                .Select(x => new DesignationDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return designation;
        }

        public async Task<string> UpdateDesignationAsync(DesignationDto designationDto)
        {
            var designation = await _context.Designations.FirstOrDefaultAsync(x => x.Id == designationDto.Id);

            if (designation != null)
            {
                designation.Name = designationDto.Name;
                designation.Description = designationDto.Description;

                await _context.SaveChangesAsync();
                return "Designation update success...!";
            }

            return "Designation not update...!";
        }

        public async Task<object> DeleteDesignationAsync(Guid id)
        {
            var designation = await _context.Designations.FirstOrDefaultAsync(x => x.Id == id);

            if (designation != null)
            {
                _context.Remove(designation);
                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }
    }
}
