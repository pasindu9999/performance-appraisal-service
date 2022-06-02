using System;
using System.Collections.Generic;
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
        public string Designation { get; set; }

        //relationship with reviwee 1:1
        //public Guid? TeamId { get; set; }
        //public virtual Team Team { get; set; }

    }
}
