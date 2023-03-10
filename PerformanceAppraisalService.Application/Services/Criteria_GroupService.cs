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
            /*//var critGroup = _context.Criteria_groups.Where(u => u.Name == criteria_groupDto.Name).Single();
          

            *//*if (critGroup != null) {

                return "Two criteria groups cant have the same name";
            }*//*
            //else
           // {
                var criteria_group = new Criteria_Group
                {
                
                Name = criteria_groupDto.Name,
                Description = criteria_groupDto.Description,
                Weightages = criteria_groupDto.Weightages,
               // WeightageCount = criteria_groupDto.Weightages+ criteria_groupDto.WeightageCount


                };

            _context.Add(criteria_group);
            await _context.SaveChangesAsync();

            return "Criteria group Create success...!";

            
        }*/
            var criteria_group = new Criteria_Group
            {
                Name = criteria_groupDto.Name,
                Description = criteria_groupDto.Description,
                

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
                    Name = x.Name,
                    Description = x.Description,
                    
                  //  WeightageCount = x.Weightages+ x.WeightageCount
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
                    Name = x.Name,
                    Description = x.Description,
                    
                   // WeightageCount = x.Weightages + x.WeightageCount
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return criteria_group;
        }

        public async Task<object> UpdateCriteria_GroupAsync(Criteria_GroupDto criteria_groupDto)
        {
            var criteria_group = await _context.Criteria_groups.FirstOrDefaultAsync(x => x.Id == criteria_groupDto.Id);

            if (criteria_group != null)
            {
                criteria_group.Name = criteria_groupDto.Name;
                criteria_group.Description = criteria_groupDto.Description;
                

                await _context.SaveChangesAsync();
                return "update sucessfull";
            }

            return "update not sucessfull";
        }

        public async Task<object> DeleteCriteria_GroupAsync(Guid id)
        {
            var criteria_group = await _context.Criteria_groups.FirstOrDefaultAsync(x => x.Id == id);

            if (criteria_group != null)
            {
                _context.Remove(criteria_group);
                await _context.SaveChangesAsync();
                return "Criteria group deleted";
            }

            return "can't delete the group";
        }

     

       
    }
}
