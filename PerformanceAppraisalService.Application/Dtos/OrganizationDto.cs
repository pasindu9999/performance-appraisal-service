using Microsoft.AspNetCore.Http;
using System;

namespace PerformanceAppraisalService.Application.Dtos
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int RegistationNumber { get; set; }
        public string WebLink { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public string BlobUrl { get; set; }
    }
}