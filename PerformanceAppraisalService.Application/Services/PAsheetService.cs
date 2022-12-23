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
    public class PAsheetService : IPAsheetService
    {

        private readonly ApplicationDbContext _context;

       

        public PAsheetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreatePAsheetAsync(PAsheetDto pasheetDto)
        {
            


            var pa_sheet = new PAsheet
            {
                DepartmentId = pasheetDto.DepartmentId,
               // Dep_Head_Name = pasheetDto.Dep_Head_Name,
                Start_date = pasheetDto.Start_date,
                Due_date = pasheetDto.Due_date,
                //  PanelId = pasheetDto.PanelId
               // RemainingTime = pasheetDto.RemainingTime

            };

            

            _context.Add(pa_sheet);
            await _context.SaveChangesAsync();

            return "PA sheet Create success...!";
        }

        public async Task<List<PAsheetDto>> GetPAsheetListAsync()
        {
            var pa_sheetList = await _context.PAsheets
                .Select(x => new PAsheetDto
                {
                    Id = x.Id,
                    DepartmentName = x.Department.Name,
                    DepartmentId = x.Department.Id,
                   // Dep_Head_Name = x.Dep_Head_Name,
                    Start_date = x.Start_date, 
                    Due_date = x.Due_date
                })
                .ToListAsync();

            return pa_sheetList;
        }

        public async Task<PAsheetDto> GetPAsheetByIdAsync(Guid id)
        {
            var pa_sheet = await _context.PAsheets
                .Select(x => new PAsheetDto
                {
                    Id = x.Id,
                   // Department = x.Department,
                   // Dep_Head_Name = x.Dep_Head_Name,
                    Start_date = x.Start_date,
                    Due_date = x.Due_date
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return pa_sheet;
        }

        public async Task<object> UpdatePAsheetAsync(PAsheetDto pasheetDto)
        {
            var pasheet = await _context.PAsheets.FirstOrDefaultAsync(x => x.Id == pasheetDto.Id);

            if (pasheet != null)
            {
               // pasheet.Department = pasheetDto.Department;
               // pasheet.Dep_Head_Name = pasheetDto.Dep_Head_Name;
                pasheet.Start_date = pasheetDto.Start_date;
                pasheet.Due_date = pasheetDto.Due_date;

                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }

        public async Task<object> DeletePAsheetAsync(Guid id)
        {
            var pasheet = await _context.PAsheets.FirstOrDefaultAsync(x => x.Id == id);

            if (pasheet != null)
            {
                _context.Remove(pasheet);
                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }

        
    }
}
