using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;

namespace PerformanceAppraisalService.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateDepartmentAsync(DepartmentDto departmentDto)
        {
            var department = new Department
            {
                Name = departmentDto.Name,
                //DepartmentHeadId = departmentDto.DepartmentHeadId,
                Description = departmentDto.Description,
                NoOfEmployees = departmentDto.NoOfEmployees
            };

            _context.Add(department);
            await _context.SaveChangesAsync();

            return "Department Create success...!";
        }

        public async Task<List<DepartmentDto>> GetDepartmentListAsync()
        {
            var departmentsList = await _context.Departments
                .Select(x => new DepartmentDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    //DepartmentHeadId = x.DepartmentHeadId,
                    Description = x.Description,
                    NoOfEmployees = x.NoOfEmployees
                })
                .ToListAsync();

            return departmentsList;
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(Guid id)
        {
            var department = await _context.Departments
                .Select(x => new DepartmentDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    //DepartmentHeadId = x.DepartmentHeadId,
                    Description = x.Description,
                    NoOfEmployees = x.NoOfEmployees
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return department;
        }

        public async Task<string> UpdateDepartmentAsync(DepartmentDto departmentDto)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == departmentDto.Id);

            if (department != null)
            {
                department.Name = department.Name;
                //department.DepartmentHead = department.DepartmentHead;
                department.Description = department.Description;
                department.NoOfEmployees = department.NoOfEmployees;

                await _context.SaveChangesAsync();
                return "Department update success...!";
            }

            return "Department not update...!";
        }

        public async Task<string> DeleteDepartmentAsync(Guid id)
        {
            var departmnent = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);

            if (departmnent != null)
            {
                _context.Remove(departmnent);
                await _context.SaveChangesAsync();
                return "Department deleted";
            }

            return "Department not deleted";
        }
    }
}
