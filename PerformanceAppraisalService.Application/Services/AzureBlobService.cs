using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
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
        private readonly AzureBlobConfigurations _blobConfigurations;

        public AzureBlobService(IOptions<AzureBlobConfigurations> blobConfigurations)
        {
            _blobConfigurations = blobConfigurations.Value;
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

            return response;
        }

        private string CreateNewFile(IFormFile iFormFile)
        {
            return Guid.NewGuid().ToString() + Path.GetExtension(iFormFile.FileName);
        }
    }
}
