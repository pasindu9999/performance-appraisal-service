using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class ReviweeDto
    {
        public Guid Id { get; set; }
        public int RegistrationNumber { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid PanelId { get; set; }        
        public string EmployeeFirstName { get; set; }
    }
}
