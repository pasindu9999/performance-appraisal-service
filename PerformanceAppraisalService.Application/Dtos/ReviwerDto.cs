using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class ReviwerDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string PanelId { get; set; }
    }
}
