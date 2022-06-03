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
                CriteriaName = criteriaDto.CriteriaName

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
                    CriteriaName = x.CriteriaName
                })
                .ToListAsync();

            return criteria;
        }

        public Task<List<CriteriaDto>> GetCriteriabyGroupAsync(Guid criteria_GroupID)
        {
            var criteriaList = _context.Criterias.Include(x => x.criteria_Group).Where(x => x.criteria_GroupID == criteria_GroupID)
                .Select(x => new CriteriaDto
                {
                    Id = x.Id,
                    CriteriaName = x.CriteriaName,
                  
                })
                .ToListAsync();

            return criteriaList;

        }




        public async Task<CriteriaDto> GetCriteriaByIdAsync(Guid id)
        {
            var criteria = await _context.Criterias
                .Select(x => new CriteriaDto
                {
                    Id = x.Id,
                    CriteriaName = x.CriteriaName
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return criteria;
        }

        public async Task<object> UpdateCriteriaAsync(CriteriaDto criteriaDto)
        {
            var criteria = await _context.Criterias.FirstOrDefaultAsync(x => x.Id == criteriaDto.Id);

            if (criteria != null)
            {
                criteria.CriteriaName = criteriaDto.CriteriaName;


                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }

        public async Task<object> DeleteCriteriaAsync(Guid id)
        {
            var criteria = await _context.Criterias.FirstOrDefaultAsync(x => x.Id == id);

            if (criteria != null)
            {
                _context.Remove(criteria);
                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }
    }
}
