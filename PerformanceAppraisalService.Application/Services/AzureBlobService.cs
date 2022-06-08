using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Services
{
    public class AzureBlobService : IAzureBlobService
    {
        private readonly AzureBlobConfiguratuions _blobConfigurations;
        private readonly ApplicationDbContext _context;
        

        public AzureBlobService(IOptions<AzureBlobConfiguratuions> blobConfigurations, ApplicationDbContext applicationDbContext)
        {
            _blobConfigurations = blobConfigurations.Value;
            _context = applicationDbContext;
        }
        public async Task<FileUploadResponseDto> UploadAsync(IFormFile iFormFile)
        {
            var client = new BlobServiceClient(_blobConfigurations.ConnectionString);
            var container = client.GetBlobContainerClient(_blobConfigurations.ImageContainerName);
            var blob = container.GetBlobClient(CreateNewFile(iFormFile));

            var fileStream = iFormFile.OpenReadStream();
            await blob.UploadAsync(fileStream, true);

            var response = new FileUploadResponseDto
            {
                ImageName = iFormFile.Name,                
                BlobUrl = blob.Uri.ToString(),
            };

            var image = new Image
            {
                BlobUrl = response.BlobUrl,
                ImageName = response.ImageName
            };

            _context.Add(image);
            await _context.SaveChangesAsync();

            return response;
            //return response;
        }

        private string CreateNewFile(IFormFile iFormFile)
        {
            return Guid.NewGuid().ToString() + Path.GetExtension(iFormFile.FileName);
        }
    }
}
