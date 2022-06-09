using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Designation: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //relationship with employee
        public ICollection<Employee> Employee { get; set; }

        //relationship with despartment table  M:N
        //public ICollection<Department> Departments { get; set; }


    }
}
