using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class PanelReviwerDto
    {
        public Guid PanelId { get; set; }
        public Guid ReviwerId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
