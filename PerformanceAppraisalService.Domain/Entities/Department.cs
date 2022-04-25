using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Department : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string DepartmentHead { get; set; }
        public string Description { get; set; }
        public int NoOfEmployees { get; set; }
    }
}

 