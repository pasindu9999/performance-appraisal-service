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
    public class SalaryService : ISalaryService
    {
        private readonly ApplicationDbContext _context;

        public SalaryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateSalaryAsync(SalaryDto salaryDto)
        {
            var salary = new Salary
            {
                BasicAmount = salaryDto.BasicAmount,
                Increment = salaryDto.Increment,
            };

            _context.Add(salary);
            await _context.SaveChangesAsync();

            return "Salary Create success...!";
        }

        public async Task<List<SalaryDto>> GetSalaryListAsync()
        {
            var salarysList = await _context.Salarys
                .Select(x => new SalaryDto
                {
                    Id = x.Id,
                    BasicAmount = x.BasicAmount,
                    Increment = x.Increment,
                })
                .ToListAsync();

            return salarysList;
        }

        public async Task<SalaryDto> GetSalaryByIdAsync(Guid id)
        {
            var salary = await _context.Salarys
                .Select(x => new SalaryDto
                {
                    Id = x.Id,
                    BasicAmount = x.BasicAmount,
                    Increment = x.Increment
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return salary;
        }

        public async Task<string> UpdateSalaryAsync(SalaryDto salaryDto)
        {
            var salary = await _context.Salarys.FirstOrDefaultAsync(x => x.Id == salaryDto.Id);

            if (salary != null)
            {
                salary.BasicAmount = salaryDto.BasicAmount;
                salary.Increment = salaryDto.Increment;

                await _context.SaveChangesAsync();
                return "Salary update success...!";
            }

            return "Salary not update...!";
        }

        public async Task<object> DeleteSalaryAsync(Guid id)
        {
            var salary = await _context.Salarys.FirstOrDefaultAsync(x => x.Id == id);

            if (salary != null)
            {
                _context.Remove(salary);
                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }
    }
}
