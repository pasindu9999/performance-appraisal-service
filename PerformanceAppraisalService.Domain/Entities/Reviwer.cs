using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Reviwer : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public virtual Employee Employee { get; set; }
        public ICollection<PanelReviwer> PanelReviwers { get; set; }
    }
}
