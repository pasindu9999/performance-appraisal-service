using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Team: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NoOfEmployees { get; set; }


        //relationship with employee
        public ICollection<Employee> Employees { get; set; }

        //relationship with designation table teamleader team 1:1
        public Guid? TeamLeaderId { get; set; }
        public Employee TeamLeader { get; set; }


        //relationship with department
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
 
    }
}
