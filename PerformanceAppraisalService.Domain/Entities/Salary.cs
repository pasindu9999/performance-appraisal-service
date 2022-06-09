using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Salary : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public double BasicAmount { get; set; }
        public double Increment { get; set; }


    }
}
