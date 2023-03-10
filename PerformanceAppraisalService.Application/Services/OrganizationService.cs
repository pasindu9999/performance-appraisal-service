using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;

namespace PerformanceAppraisalService.Application.Services
{
    public class OrganizationService: IOrganizationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAzureBlobService _azureBlobService;
        
        public OrganizationService(ApplicationDbContext context, IAzureBlobService azureBlobService) 
        {
            _context = context;
            _azureBlobService = azureBlobService;
            
        }

        public async Task<string> CreateOrganizationAsync(OrganizationDto organizationDto)
        {
           //var imgresponse = await _azureBlobService.UploadAsync(organizationDto.Image);
           

            var organizaion = new Organization
            {
                Name = organizationDto.Name,
                Address = organizationDto.Address,
                RegistationNumber = organizationDto.RegistationNumber,                
                WebLink=organizationDto.WebLink,
                Email = organizationDto.Email
            };


            _context.Add(organizaion);
            await _context.SaveChangesAsync();

            return "Organization Create success...!";
        }

        
        
        public async Task<List<OrganizationDto>> GetOrganizationListAsync()
        {
            var orgaznizationsList = await _context.Organizations
                .Select(x=> new OrganizationDto
                {
                    Id =x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    RegistationNumber = x.RegistationNumber,
                    WebLink=x.WebLink,
                    
                })
                .ToListAsync();

            return orgaznizationsList;
        }

        public async Task<OrganizationDto> GetOrganizationByIdAsync(Guid id)
        {
            var orgaznization = await _context.Organizations
                .Select(x=> new OrganizationDto
                {
                    Id =x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    RegistationNumber = x.RegistationNumber,
                    WebLink=x.WebLink
                })
                .FirstOrDefaultAsync(x=> x.Id == id);

            return orgaznization;
        }
        
        public async Task<object> UpdateOrganizationAsync(OrganizationDto organizationDto)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == organizationDto.Id);

            if (organization != null)
            {
                organization.Name = organizationDto.Name;
                organization.Address = organizationDto.Address;
                organization.RegistationNumber = organizationDto.RegistationNumber;
                organization.WebLink = organizationDto.WebLink;
                
                
                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }

        public async Task<object> DeleteOrganizationAsync(Guid id)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == id);
            
            if (organization != null)
            {
                _context.Remove(organization);
                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }
    }
}