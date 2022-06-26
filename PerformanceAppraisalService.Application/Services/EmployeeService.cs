using Microsoft.EntityFrameworkCore;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    DesignationId = employeeDto.DesignationId
                };

                _context.Add(employee);
                await _context.SaveChangesAsync();

                return "Employee Create success...!";
            
        }

        public async Task<List<EmployeeDto>> GetEmployeeListAsync()
        {
            var employeeList = await _context.Employees.GroupJoin(_context.Departments, ai => ai.DepartmentId, di => di.Id,
                    (ai, di) => new { ai, di }
                    ).SelectMany (x => x.di.DefaultIfEmpty(), (empData, depData) => 
                    new EmployeeDto{ 
                        Id = empData.ai.Id,
                        RegistrationNumber = empData.ai.RegistrationNumber,
                        FirstName = empData.ai.FirstName,
                        LastName = empData.ai.LastName,
                        Email = empData.ai.Email,
                        DesignationId = empData.ai.DesignationId,
                        DesignationName = empData.ai.Designation.Name,
                        DepartmentId = (Guid)empData.ai.DepartmentId,
                        DepartmentName = depData.Name,
                        TeamId = (Guid)empData.ai.TeamId,
                        Imageurl = empData.ai.Imageurl,
                        Certificateurl = empData.ai.Certificateurl

                    }).ToListAsync();
                  

            return employeeList;
        }

        //filter according to the departments
        public async Task<List<EmployeeDto>> GetEmployeesbyDepartmentAsync(Guid departmentId)
        {
            var employeeList = await _context.Employees.Join(_context.Departments, ai => ai.DepartmentId, di => di.Id, (ai, di) =>
                     new EmployeeDto
                     {
                        Id = ai.Id,
                        RegistrationNumber = ai.RegistrationNumber,
                        FirstName = ai.FirstName,
                        LastName = ai.LastName,
                        Email = ai.Email,
                        DesignationId = ai.DesignationId,
                        DesignationName = ai.Designation.Name,
                        DepartmentId = (Guid)ai.DepartmentId,
                        DepartmentName = di.Name,
                        TeamId = (Guid)ai.TeamId,
                        Imageurl = ai.Imageurl,
                        Certificateurl = ai.Certificateurl
                     }).Where(ai => ai.DepartmentId == departmentId)
                .ToListAsync();

                return employeeList;

        }

  
        //filter according to the teams n
        public async Task<List<EmployeeDto>> GetEmployeesbyTeamAsync(Guid teamId)
        {
            var employeeList = await _context.Employees.Join(_context.Teams, ai => ai.TeamId, ti => ti.Id, (ai, ti) =>
                    new EmployeeDto
                    {
                        Id = ai.Id,
                        RegistrationNumber = ai.RegistrationNumber,
                        FirstName = ai.FirstName,
                        LastName = ai.LastName,
                        Email = ai.Email,
                        DesignationId = ai.DesignationId,
                        DesignationName = ai.Designation.Name,
                        DepartmentId = (Guid)ai.DepartmentId,
                        //DepartmentName = di.Name,
                        TeamId = (Guid)ai.TeamId,
                        TeamName = ti.Name,
                        Imageurl = ai.Imageurl,
                        Certificateurl = ai.Certificateurl
                    }).Where(ai => ai.TeamId == teamId)
                .ToListAsync();

                return employeeList;

        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _context.Employees.GroupJoin(_context.Departments, ai => ai.DepartmentId, di => di.Id,
                    (ai, di) => new { ai, di }
                    ).SelectMany(x => x.di.DefaultIfEmpty(), (empData, depData) =>
                   new EmployeeDto
                   {
                       Id = empData.ai.Id,
                       RegistrationNumber = empData.ai.RegistrationNumber,
                       FirstName = empData.ai.FirstName,
                       LastName = empData.ai.LastName,
                       Email = empData.ai.Email,
                       DesignationId = empData.ai.DesignationId,
                       DesignationName = empData.ai.Designation.Name,
                       DepartmentId = (Guid)empData.ai.DepartmentId,
                       DepartmentName = depData.Name,
                       TeamId = (Guid)empData.ai.TeamId,
                       Imageurl = empData.ai.Imageurl,
                       Certificateurl = empData.ai.Certificateurl

                   })
                .FirstOrDefaultAsync(x => x.Id == id);

            return employee;
        }

        public async Task<string> UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employeeDto.Id);

            if (employee != null)
            {
                employee.RegistrationNumber = employeeDto.RegistrationNumber;
                employee.FirstName = employeeDto.FirstName;
                employee.LastName = employeeDto.LastName;
                employee.Email = employeeDto.Email;
                employee.DesignationId = employeeDto.DesignationId;
                employee.DepartmentId = employeeDto.DepartmentId;
                employee.TeamId = employeeDto.TeamId;
                await _context.SaveChangesAsync();
                return "Employee update success...!";
            }

            return "Employee not update...!";
        }



        public async Task<string> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync();
                return "Delete employee sucess..!";
            }

            return "Can't Delete employee";
        }



    }
}
