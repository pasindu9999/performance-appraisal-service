using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class PanelDto
    {
        public string PanelNumber { get; set; }
        public Guid PanelReviwers { get; set; }

        public Guid Reviwees { get; set; }
    }
}
