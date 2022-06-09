using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string ImageName { get; set; }
        public string BlobUrl { get; set; }
    }
}
