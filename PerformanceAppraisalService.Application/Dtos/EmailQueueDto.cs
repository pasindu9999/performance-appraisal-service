using PerformanceAppraisalService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class EmailQueueDto
    {
        public EmailType EmailType { get; set; }

        public Guid UserId { get; set; }

        public string Url { get; set; }
    }
}
