using PerformanceAppraisalService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IQueueService
    {
        Task<string> SendToQueue(string email, EmailType type);
    }
}
