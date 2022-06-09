using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IRegistrationEmailProcessor
    {
        void Process(Guid userId, string url);
    }
}
