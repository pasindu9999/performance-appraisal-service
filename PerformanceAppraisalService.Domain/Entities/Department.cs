using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? NoOfEmployees { get; set; }

        //relationship with team table 1 : M
        public ICollection<Team> Teams { get; set; }
        public ICollection<Employee> Employees { get; set; }


        //relationship with designation table  M:N
        //public ICollection<Designation> Designations { get; set; }


        //relationship with employee table department head department 1:1
        public Guid? DepartmentHeadId { get; set; }
        public Employee DepartmentHead { get; set; }
    }
}

 