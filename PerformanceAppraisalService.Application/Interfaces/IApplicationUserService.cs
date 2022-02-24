using PerformanceAppraisalService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IApplicationUserService
    {
        Task<Object> PostApplicationUser(ApplicationUserDto applicationUserDto);
    }
}
