using PerformanceAppraisalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class PAsheet : BaseEntity
    {
        //public string Department { get; set; }
        //public string Dep_Head_Name { get; set; }

        public DateTime Start_date { get; set; }
        public DateTime Due_date { get; set; }

        public Guid? PanelId { get; set; }

        public virtual  Panel Panel {get; set;}

        public Guid? DepartmentId { get; set; }
        public Department Department { get; set; }
        
        
    }
}
