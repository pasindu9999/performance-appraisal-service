using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class PAsheetDto
    {
        public Guid Id { get; set; }
        public string Department { get; set; }
        public string Dep_Head_Name { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime Due_date { get; set; }

        public Guid PanelId { get; set; }


    }
}
