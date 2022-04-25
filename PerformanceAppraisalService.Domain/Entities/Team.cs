using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Team: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public int NoOfEmployees { get; set; }
    }
}
