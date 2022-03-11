using Create_PA.application.Dtos;
using Create_PA.application.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Create_PA.domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;

namespace Create_PA.application.Services
{
    public class PA_sheetService : IPA_sheetService
    {

        private readonly ApplicationDbContext _context;

        public PA_sheetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreatePA_sheetAsync(PA_sheet_Dto pa_sheet_Dto)
        {
            var pa_sheet = new PA_Sheet
            {
                Employee_Name = pa_sheet_Dto.Employee_Name,
                Designation = pa_sheet_Dto.Designation,
                Dep_Head_Name = pa_sheet_Dto.Dep_Head_Name,
                Due_date = pa_sheet_Dto.Due_date

            };

            _context.Add(pa_sheet);
            await _context.SaveChangesAsync();

            return "PA sheet Create success...!";
        }

        public async Task<List<PA_sheet_Dto>> GetPA_sheetListAsync()
        {
            var pa_sheetList = await _context.PA_lists
                .Select(x => new PA_sheet_Dto
                {
                    Id = x.Id,
                    Employee_Name = x.Employee_Name,
                    Designation = x.Designation,
                    Dep_Head_Name = x.Dep_Head_Name,
                    Due_date = x.Due_date
                })
                .ToListAsync();

            return pa_sheetList;
        }

        public async Task<PA_sheet_Dto> GetPA_sheetByIdAsync(Guid id)
        {
            var pa_sheet = await _context.PA_lists
                .Select(x => new PA_sheet_Dto
                {
                    Id = x.Id,
                    Employee_Name = x.Employee_Name,
                    Designation = x.Designation,
                    Dep_Head_Name = x.Dep_Head_Name,
                    Due_date = x.Due_date
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return pa_sheet;
        }

        public async Task<string> UpdatePA_sheetAsync(PA_sheet_Dto pa_sheet_Dto)
        {
            var pa_sheet = await _context.PA_lists.FirstOrDefaultAsync(x => x.Id == pa_sheet_Dto.Id);

            if (pa_sheet != null)
            {
                pa_sheet.Employee_Name = pa_sheet_Dto.Employee_Name;
                pa_sheet.Designation = pa_sheet_Dto.Designation;
                pa_sheet.Dep_Head_Name = pa_sheet_Dto.Dep_Head_Name;
                pa_sheet.Due_date = pa_sheet_Dto.Due_date;

                await _context.SaveChangesAsync();
                return "pa sheet update success...!";
            }

            return "pa sheet not update...!";
        }

        public async Task<string> DeletePA_sheetAsync(Guid id)
        {
            var pa_sheet = await _context.PA_lists.FirstOrDefaultAsync(x => x.Id == id);

            if (pa_sheet != null)
            {
                _context.Remove(pa_sheet);
                await _context.SaveChangesAsync();
                return "pa sheet deleted...!";
            }

            return "can not delete pa sheet";
        }

    }
}
