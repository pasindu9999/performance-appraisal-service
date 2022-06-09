using PerformanceAppraisalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
   public class Criteria_Group : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weightages { get; set; }
        public ICollection<Criteria> Criterias { get; set; }

    }
}
