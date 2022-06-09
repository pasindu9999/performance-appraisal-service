using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class ResultDto
    {
        public Guid Id { get; set; }
        public Guid CriteriaId { get; set; }
        public Guid ReviwerId { get; set; }
        public Guid ReviweeId { get; set; }
        public int Marks { get; set; }
    }
}
