using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Infrastructure.Data
{
    public class AzureBlobConfigurations
    {
        public string ConnectionString { get; set; }
        public string ImageContainerName { get; set; }
    }
}
