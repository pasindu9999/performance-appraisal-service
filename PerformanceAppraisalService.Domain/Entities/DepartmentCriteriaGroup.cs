using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
   public class DepartmentCriteriaGroup : BaseEntity
    {
        public int Weightage { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }

        public Guid CriteriaGroupId { get; set; }

        public Criteria_Group CriteriaGroup { get; set; }



    }
}
