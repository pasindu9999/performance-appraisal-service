using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public string Description { get; set; }
        public int NoOfEmployees { get; set; }
        public string DepartmentName { get; set; }
        public Guid? TeamLeaderId { get; set; }
        public string TeamLeaderFirstName { get; set; }


    }
}
