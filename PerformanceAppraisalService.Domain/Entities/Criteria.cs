using PerformanceAppraisalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Criteria : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid GroupId { get; set; }
        public Criteria_Group Group { get; set; }

    }
}
