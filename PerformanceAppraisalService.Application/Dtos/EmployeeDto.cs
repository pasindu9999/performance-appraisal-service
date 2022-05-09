using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public int RegistrationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public Guid DepartmentId { get; set; }
        //public Guid TeamId { get; set; }
        //public Guid DesignationId { get; set; }
        //public Guid DepartmentHeadId { get; set; }
        //public Guid TeamLeaderId { get; set; }

    }
}
