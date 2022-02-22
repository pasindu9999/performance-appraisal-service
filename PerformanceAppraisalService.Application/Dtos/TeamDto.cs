using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public string tName { get; set; }
        public string depName { get; set; }
        public string tDescription { get; set; }
        public int noOfEmployees { get; set; }
    }
}
