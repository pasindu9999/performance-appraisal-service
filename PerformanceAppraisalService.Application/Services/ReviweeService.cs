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
    public class ReviweeService : IReviweeService
    {
        private readonly ApplicationDbContext _context;
        public ReviweeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateReviweeAsync(ReviweeDto reviweeDto)
        {
           
            var reviwee = new Reviwee
            {
                PanelId = reviweeDto.PanelId,
                EmployeeId = reviweeDto.EmployeeId,
                EmployeeFirstName = reviweeDto.EmployeeFirstName
            };

            _context.Add(reviwee);
            await _context.SaveChangesAsync();

            return "Reviwee added Successfully";
        }

        public async Task<string> DeleteReviweeAsync(Guid id)
        {
            var reviwee = await _context.Reviwees.FirstOrDefaultAsync(x => x.Id == id);

            if (reviwee != null)
            {
                _context.Remove(reviwee);
                await _context.SaveChangesAsync();
                return "Reviwee deleted successfully";
            }

            return "Reviwee deleted failed";
        }

        public async Task<ReviweeDto> GetReviweeByIdAsync(Guid id)
        {
            var reviwee = await _context.Reviwees.Include(x => x.Employee)
                .Select(x => new ReviweeDto
                {
                    Id = x.Id,
                    EmployeeFirstName = x.EmployeeFirstName,
                    EmployeeId = x.EmployeeId,
                    DepartmentName = (string)x.Employee.DepartmentName,
                    PanelId = (Guid)x.PanelId
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return reviwee;
        }

        public async Task<List<ReviweeDto>> GetReviweeListAsync()
        {
            var reviweeList = await _context.Reviwees
                .Select(x => new ReviweeDto
                {
                    Id = x.Id,
                    EmployeeFirstName = x.EmployeeFirstName,
                    DepartmentName = (string)x.Employee.DepartmentName,
                    EmployeeId = x.EmployeeId,
                    PanelId = (Guid)x.PanelId
                })
                .ToListAsync();

            return reviweeList;
        }

        public async Task<string> UpdateReviweeAsync(ReviweeDto reviweeDto)
        {
            var reviwee = await _context.Reviwees.FirstOrDefaultAsync(x => x.Id == reviweeDto.Id);

            if (reviwee != null)
            {
                reviwee.PanelId = reviweeDto.PanelId;

                await _context.SaveChangesAsync();
                return "Reviwee updated Success";
            }

            return "Reviwee not updated";
        }
    }
}
