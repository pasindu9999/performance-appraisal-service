using Create_Criteria_Group.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Criteria : BaseEntity
    {
        public string CriteriaName { get; set; }

        public Guid? criteria_GroupID { get; set; }

        public Criteria_Group criteria_Group { get; set; }
    }
}
