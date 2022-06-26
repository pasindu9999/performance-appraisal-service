using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Employee: BaseEntity
    {       

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistrationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Certificateurl { get; set; }
        public string Imageurl { get; set; }
         //public virtual Department DepartmentHead { get; set; }


        //relationship with designation 1:m
        public Guid DesignationId { get; set; }
        public virtual Designation Designation { get; set; }


        //relationship with department 1:m
        public Guid? DepartmentId { get; set; }
        public virtual Department Department { get; set; }


        //relationship with team 1:m
        public Guid? TeamId { get; set; }
        public virtual Team Team { get; set; }

        public Reviwer Reviwer { get; set; }
        public Reviwee Reviwee { get; set; }

        //relationship with reviwee 1:1
        //public Guid? TeamId { get; set; }
        //public virtual Team Team { get; set; }

    }
}
