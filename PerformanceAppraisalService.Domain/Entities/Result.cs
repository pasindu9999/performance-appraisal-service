using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Result: BaseEntity
    {
        public Guid CriteriaId { get; set; }
        public Guid? ReviwerId { get; set; }
        public Guid? ReviweeId { get; set; }
        public  int? Marks { get; set; }
        public virtual Criteria Criteria { get; set; }
        public virtual Reviwer Reviwer { get; set; }
        public virtual Reviwee Reviwee { get; set; }

        public object Sum(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
