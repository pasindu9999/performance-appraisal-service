using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class FileUploadResponseDto
    {
        public IFormFile file { get; set; }
    }
}
