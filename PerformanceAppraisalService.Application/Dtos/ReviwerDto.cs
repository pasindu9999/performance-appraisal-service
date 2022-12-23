using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class ReviwerDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid EmployeeDepartmentId { get; set; }
        public Guid? PanelId { get; set; }
        public string EmployeeFirstName { get; set; }
        public int EmployeeRegisterNumber { get; set; }
        public string DepartmentName { get; set; }
        
        public int PanelNumber { get; set; }

      
    }
}
