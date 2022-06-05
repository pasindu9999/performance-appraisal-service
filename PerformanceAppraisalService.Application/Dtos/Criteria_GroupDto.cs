using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class Criteria_GroupDto
    {
        public Guid Id { get; set; }

        public string CriteriaGroup { get; set; }

        public int weightage { get; set; }
    }
}
