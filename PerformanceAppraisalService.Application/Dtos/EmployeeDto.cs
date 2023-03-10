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
        public string Imageurl { get; set; }
        public string Certificateurl { get; set; }
        public Guid DesignationId { get; set; }
        public string DesignationName { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get ; set; }
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
 
    }
}
