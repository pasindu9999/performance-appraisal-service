using Microsoft.EntityFrameworkCore;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Services
{
    public class Criteria_Service : ICriteria_Service
    {
        private readonly ApplicationDbContext _context;

        public Criteria_Service(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Create_criteriaAsync(CriteriaDto criteriaDto)
        {
            var criteria = new Criteria
            {
                Name = criteriaDto.Name,
                Description = criteriaDto.Description,
                GroupId = criteriaDto.GroupId

            };

            _context.Add(criteria);
            await _context.SaveChangesAsync();

            return "Criteria Create success...!";
        }

        public async Task<List<CriteriaDto>> GetCriteriaAsync()
        {
            var criteria = await _context.Criterias
                .Select(x => new CriteriaDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    GroupId = x.GroupId
                })
                .ToListAsync();

            return criteria;
        }

        public async Task<List<CriteriaDto>> GetCriteriabyCriteriaGroupAsync(Guid CriteriaGroupId)
        {
            var criteria = await _context.Criterias.Where(x => x.GroupId == CriteriaGroupId)
                .Select(x => new CriteriaDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    GroupId = x.GroupId

                })
                .ToListAsync();

            return criteria;
        }
        public async Task<CriteriaDto> GetCriteriaByIdAsync(Guid id)
        {
            var criteria = await _context.Criterias
                .Select(x => new CriteriaDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    GroupId = x.GroupId
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return criteria;
        }

        public async Task<string> UpdateCriteriaAsync(CriteriaDto criteriaDto)
        {
            var criteria = await _context.Criterias.FirstOrDefaultAsync(x => x.Id == criteriaDto.Id);

            if (criteria != null)
            {
                criteria.Name = criteriaDto.Name;
                criteria.Description = criteriaDto.Description;
               // criteria.GroupId = criteriaDto.GroupId;

                await _context.SaveChangesAsync();
                return "criteria updated";
            }

            return "criteria not updated";
        }

        public async Task<object> DeleteCriteriaAsync(Guid id)
        {
            var criteria = await _context.Criterias.FirstOrDefaultAsync(x => x.Id == id);

            if (criteria != null)
            {
                _context.Remove(criteria);
                await _context.SaveChangesAsync();
                return "criteria deleted";
            }

            return "criteria not deleted";
        }

       

        
    }
}
