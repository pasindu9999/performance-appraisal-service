using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IForgotPasswordEmailProcessor
    {
        void Process(Guid userId, string url);
    }
}
