using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string DepartmentHead { get; set; }
        public string Description { get; set; }
        public int NoOfEmployees { get; set; }
    }
}
