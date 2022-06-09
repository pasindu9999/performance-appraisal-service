using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Domain.Entities
{
    public class AzureBlobConfiguratuions
    {
        public string ConnectionString { get; set; }
        public string ImageContainerName { get; set; }
    }
}
