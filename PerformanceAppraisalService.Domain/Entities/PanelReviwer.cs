using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class PanelReviwer
    {
        public DateTime CreateDate { get; set; }
        public Guid PanelId { get; set; }
        public Panel Panel { get; set; }

        public Guid ReviwerId { get; set; }
        public Reviwer Reviwer { get; set; }
    }

    
}
