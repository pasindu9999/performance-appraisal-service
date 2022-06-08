using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class FileUploadResponseDto
    {
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public string BlobUrl { get; set; }

    }
}
