using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Reviwer : BaseEntity
    {
        public string PanelId { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Panel Panel { get; set; }
        public virtual Employee Employee { get; set; }
       
    }
}
