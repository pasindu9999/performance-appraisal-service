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
    public class EmployeeService: IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                RegistrationNumber = employeeDto.RegistrationNumber,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Designation = employeeDto.Designation
            };

            _context.Add(employee);
            await _context.SaveChangesAsync();

            return "Employee Create success...!";
        }

        public async Task<List<EmployeeDto>> GetEmployeeListAsync()
        {
            var employeesList = await _context.Employees
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    RegistrationNumber = x.RegistrationNumber,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Designation = x.Designation
                })
                .ToListAsync();

            return employeesList;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _context.Employees
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    RegistrationNumber = x.RegistrationNumber,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Designation = x.Designation
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return employee;
        }

        public async Task<string> UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employeeDto.Id);

            if (employee != null)
            {
                employee.RegistrationNumber = employee.RegistrationNumber;
                employee.FirstName = employee.FirstName;
                employee.LastName = employee.LastName;
                employee.Email = employee.Email;
                employee.Designation = employeeDto.Designation;

                await _context.SaveChangesAsync();
                return "Employee update success...!";
            }

            return "Employee not update...!";
        }

        public async Task<object> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }
    }
}
