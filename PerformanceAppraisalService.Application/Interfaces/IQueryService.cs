using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IQueryService
    {
        Task<object> ShowCount();
        Task<object> GetRevieweemarks(Guid id);
        Task<object> GetRevieweemarksbyGroup(Guid id);
        Task<object> GetTotalmarksbyReviwee(Guid id);
        Task<object> GetTotalGroupmarksbydepartment(Guid id);
        Task<object> GetTotalGroupmarksbyteam(Guid id);
        Task<object> GetTotalDepartmentsMarks();
        Task<int> NoOfEmployees();
        Task<int> NoOfDepartments();
        Task<int> NoOfTeams();
    }
}
