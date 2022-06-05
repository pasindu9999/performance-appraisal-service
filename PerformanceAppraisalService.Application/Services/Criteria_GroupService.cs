using Create_Criteria_Group.Domain.Entities;
using Create_PA.domain.Entities;
using Microsoft.EntityFrameworkCore;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceAppraisalService.Application.Services
{
    public class Criteria_GroupService : ICriteria_GroupService
    {
        private readonly ApplicationDbContext _context;

        public Criteria_GroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Create_criteriaGroupAsync(Criteria_GroupDto criteria_groupDto)
        {
            var criteria_group = new Criteria_Group
            {
                CriteriaGroup = criteria_groupDto.CriteriaGroup,
                weightage = criteria_groupDto.weightage

            };

            _context.Add(criteria_group);
            await _context.SaveChangesAsync();

            return "Criteria group Create success...!";
        }

        public async Task<List<Criteria_GroupDto>> GetCriteria_groupAsync()
        {
            var criteria_group = await _context.Criteria_groups
                .Select(x => new Criteria_GroupDto
                {
                    Id = x.Id,
                    CriteriaGroup = x.CriteriaGroup,
                    weightage = x.weightage
                })
                .ToListAsync();

            return criteria_group;
        }

        public async Task<Criteria_GroupDto> GetCriteria_GroupByIdAsync(Guid id)
        {
            var criteria_group = await _context.Criteria_groups
                .Select(x => new Criteria_GroupDto
                {
                    Id = x.Id,
                    CriteriaGroup = x.CriteriaGroup,
                     weightage = x.weightage
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return criteria_group;
        }

        public async Task<object> UpdateCriteria_GroupAsync(Criteria_GroupDto criteria_groupDto)
        {
            var criteria_group = await _context.Criteria_groups.FirstOrDefaultAsync(x => x.Id == criteria_groupDto.Id);

            if (criteria_group != null)
            {
                criteria_group.CriteriaGroup = criteria_groupDto.CriteriaGroup;
                criteria_group.weightage = criteria_groupDto.weightage;


                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }

        public async Task<object> DeleteCriteria_GroupAsync(Guid id)
        {
            var criteria_group = await _context.Criteria_groups.FirstOrDefaultAsync(x => x.Id == id);

            if (criteria_group != null)
            {
                _context.Remove(criteria_group);
                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }

       
    }
}
