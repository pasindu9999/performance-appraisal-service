using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string dName { get; set; }
        public string dDescription { get; set; }
        public int noOfEmployees { get; set; }
    }
}

