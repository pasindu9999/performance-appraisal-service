using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Team: BaseEntity
    {
        public string tName { get; set; }
        public string depName { get; set; }
        public string tDescription { get; set; }
        public int noOfEmployees { get; set; }
    }
}
