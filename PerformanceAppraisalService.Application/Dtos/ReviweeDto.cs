using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class ReviweeDto
    {
        public Guid? Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid? PanelId { get; set; }
        public int PanelNumber { get; set; }
        public int EmployeeRegistationNumber { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeFirstName { get; set; }

        public Guid pasheetId { get; set; }
    }
}
