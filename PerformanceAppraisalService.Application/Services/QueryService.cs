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
    public class QueryService : IQueryService
    {
        private readonly ApplicationDbContext _context;
        public QueryService(ApplicationDbContext context)
        {
            _context = context;
        }

      

        public Task<object> ShowCount()
        {
            // int count =  _context.Employees.Count();
            //var count1 = _context.Employees.GroupBy(x => x.DepartmentId).Count();
            //return count;

            var query = _context.Employees
                       .Where(a=>a.DepartmentId != null)
                       .GroupBy(p => p.DepartmentId)
                       .Select(g => new { Id= g.Key ,count = g.Count() });
            return (Task<object>)query;

        }

        public async Task<object> GetRevieweemarks(Guid id)
        {
            var marks =await _context.Results.Where(x => x.ReviweeId == id)
                       .GroupBy(a => a.ReviwerId)
                       .Select(g => new
                       {
                           Id = g.Key,
                           Marks = g.Sum(m => m.Marks)
                       }).ToListAsync();
                       
            return marks;
        }

        public async Task<object> GetRevieweemarksbyGroup(Guid id)
        {
            var groupmarks = _context.Results.Include(x=>x.Criteria).ThenInclude(x=>x.Group).Where(x => x.ReviweeId == id)
                             .GroupBy(a =>new { a.Criteria.GroupId,a.ReviwerId,a.Criteria.Group.Name,a.Reviwer.Employee.FirstName})
                             .Select(c => new
                             {
                                 GroupId = c.Key.GroupId,
                                 GroupName = c.Key.Name,
                                 ReviwerId = c.Key.ReviwerId,
                                 ReviwerName = c.Key.FirstName,
                                 totalMarks = c.Sum(x => x.Marks)
                             });
        
           
            return groupmarks;
        }

        //Get Criteria groups marks when give the department Id
        public async Task<object> GetTotalGroupmarksbydepartment(Guid id)
        {
            var dgroupmarks = _context.Results.Include(x=>x.Criteria).ThenInclude(x=>x.Group).Where(x=>x.Reviwee.Employee.DepartmentId ==id)
                               .GroupBy(a => new {a.Criteria.GroupId, a.Criteria.Group.Name})
                               .Select(c=>new
                               {
                                   GroupId = c.Key.GroupId,
                                   GroupName = c.Key.Name,
                                   totalMarks = c.Sum(x=>x.Marks)
                               });

            return dgroupmarks;
        }

        //Get Criteria groups marks when give the team Id
        public async Task<object> GetTotalGroupmarksbyteam(Guid id)
        {
            var tgroupmarks = _context.Results.Include(x => x.Criteria).ThenInclude(x => x.Group).Where(x => x.Reviwee.Employee.TeamId == id)
                               .GroupBy(a => new { a.Criteria.GroupId, a.Criteria.Group.Name })
                               .Select(c => new
                               {
                                   GroupId = c.Key.GroupId,
                                   GroupName = c.Key.Name,
                                   TotalMarks = c.Sum(x => x.Marks)
                               });

            return tgroupmarks;
        }

        //Get all average marks departmentvise
        public async Task<object> GetTotalDepartmentsMarks()
        {
            var departmentMarks = _context.Results
                                  .GroupBy(x => new { x.Reviwee.Employee.DepartmentId, x.Reviwee.Employee.Department.Name })
                                  .Select(c => new
                                  {
                                      DepartmentId = c.Key.DepartmentId,
                                      DepartmentName = c.Key.Name,
                                      TotalMarks = c.Sum(x => x.Marks)
                                  });

            return departmentMarks;
        }


        public async Task<object> GetTotalmarksbyReviwee(Guid id)
        {
            var totalMarks = _context.Results.Where(x => x.ReviweeId == id)
                            .GroupBy(a => a.ReviweeId)
                            .Select(a => new
                            {
                                Id = a.Key,
                                totalMarks = a.Sum(x => x.Marks)
                            });
                        
            return totalMarks;
        }






        public async Task<int> NoOfEmployees()
        {
            var noOfEmployee = _context.Employees.Count();
            return noOfEmployee;
        }

        public async Task<int> NoOfDepartments()
        {
            var noOfDepartments = _context.Departments.Count();
            return noOfDepartments;
        }

        public async Task<int> NoOfTeams()
        {
            var noOfTeams = _context.Teams.Count();
            return noOfTeams;
        }


    }




}
