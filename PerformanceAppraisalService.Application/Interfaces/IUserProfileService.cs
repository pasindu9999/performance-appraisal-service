using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<object> GetUserProfile();
    }
}
