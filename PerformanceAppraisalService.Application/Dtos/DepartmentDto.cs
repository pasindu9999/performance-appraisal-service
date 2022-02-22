using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string dName { get; set; }
        public string dDescription { get; set; }
        public int noOfEmployees { get; set; }
    }
}
