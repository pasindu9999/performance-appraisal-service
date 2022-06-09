using PerformanceAppraisalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class PAsheet : BaseEntity
    {
        public string Department { get; set; }
        public string Dep_Head_Name { get; set; }

        public DateTime Start_date { get; set; }
        public DateTime Due_date { get; set; }
    }
}
