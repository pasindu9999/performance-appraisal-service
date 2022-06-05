using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class PanelDto
    {
        public Guid Id { get; set; }
        public int PanelNumber { get; set; }
        public Guid ReviwerId { get; set; }
        public Guid Reviwees { get; set; }
    }
}
