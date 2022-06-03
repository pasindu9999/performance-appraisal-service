using PerformanceAppraisalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Create_Criteria_Group.Domain.Entities
{
   public class Criteria_Group : BaseEntity
    {
        public string CriteriaGroup { get; set; }

        public ICollection<Criteria> Criterias { get; set; }
    }
}
