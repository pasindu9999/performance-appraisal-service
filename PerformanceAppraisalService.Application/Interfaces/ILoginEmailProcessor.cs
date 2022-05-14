using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Interfaces
{
    public interface ILoginEmailProcessor
    {
        void Process(Guid userId);
    }
}
