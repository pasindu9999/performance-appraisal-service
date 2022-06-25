using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
   public class DepartmentCriteriaGroupDto
    {
        public Guid Id { get; set; }
        public int Weightage { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid CriteriaGroupId { get; set; }

        public string Name { get; set; }


    }
}
