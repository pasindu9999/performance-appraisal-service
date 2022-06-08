using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface IConfirmEmailProcessor
    {
        void Process(Guid userId, string url);
    }
}
