using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;

namespace PerformanceAppraisalService.Application.Services
{
    public class OrganizationService: IOrganizationService
    {
        private readonly ApplicationDbContext _context;
        
        public OrganizationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateOrganizationAsync(OrganizationDto organizationDto)
        {
            var organizaion = new Organization
            {
                Name = organizationDto.Name,
                Address = organizationDto.Address,
                RegistationNumber = organizationDto.RegistationNumber
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
                    RegistationNumber = x.RegistationNumber
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
                    RegistationNumber = x.RegistationNumber
                })
                .FirstOrDefaultAsync(x=> x.Id == id);

            return orgaznization;
        }
        
        public async Task<string> UpdateOrganizationAsync(OrganizationDto organizationDto)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == organizationDto.Id);

            if (organization != null)
            {
                organization.Name = organizationDto.Name;
                organization.Address = organizationDto.Address;
                organization.RegistationNumber = organizationDto.RegistationNumber;
                
                await _context.SaveChangesAsync();
                return "Organization update success...!";
            }

            return "Organization not update...!";
        }

        public async Task<string> DeleteOrganizationAsync(Guid id)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == id);
            
            if (organization != null)
            {
                _context.Remove(organization);
                await _context.SaveChangesAsync();
                return "Organization deleted...!";
            }

            return "can not delete organization";
        }
    }
}