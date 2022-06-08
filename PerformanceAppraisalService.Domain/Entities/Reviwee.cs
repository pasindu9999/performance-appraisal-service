﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Reviwee : BaseEntity
    {
        
        public Guid PanelId { get; set; }
        public Guid EmployeeId { get; set; }     
        public virtual Employee Employee { get; set; }
        public virtual Panel Panel { get; set; }
   
    }
}
