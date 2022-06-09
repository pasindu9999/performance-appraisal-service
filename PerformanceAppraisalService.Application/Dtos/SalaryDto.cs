using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class SalaryDto
    {
        public Guid Id { get; set; }
        public double BasicAmount { get; set; }
        public double Increment { get; set; }
    }
}
