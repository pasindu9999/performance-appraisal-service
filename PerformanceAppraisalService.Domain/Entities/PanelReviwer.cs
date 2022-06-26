using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class PanelReviwer : BaseEntity
    {
        public Guid PanelId { get; set; }
        public Panel Panel { get; set; }

        public Guid ReviwerId { get; set; }
        public Reviwer Reviwer { get; set; }
    }

    
}
