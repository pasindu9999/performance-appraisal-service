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
   public class DepartmentCriteriaGroupService : IDepartmentCriteriaGroupService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentCriteriaGroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateDepartmentCriteriaGroupAsync(DepartmentCriteriaGroupDto departmentCriteriaGroupDto)
        {
            var criteriaGroupList = await _context.DepartmentCriteriaGroups.Include(x => x.CriteriaGroup).Where(x => x.DepartmentId == departmentCriteriaGroupDto.DepartmentId && x.CriteriaGroupId == departmentCriteriaGroupDto.CriteriaGroupId)
                 .FirstOrDefaultAsync();

            if (criteriaGroupList != null)
            {
                return "Alredy added";
            }

            var departmentCriteriaGroup = new DepartmentCriteriaGroup
            {
                Weightage = departmentCriteriaGroupDto.Weightage,
                CriteriaGroupId = departmentCriteriaGroupDto.CriteriaGroupId,
                DepartmentId = departmentCriteriaGroupDto.DepartmentId
            };


            _context.Add(departmentCriteriaGroup);
            await _context.SaveChangesAsync();

            return "criteria group added successfully...!";
        }

        public async Task<List<DepartmentCriteriaGroupDto>> GetDepartmentCriteria_groupAsync()
        {

            var departmentCriteriaGroup = await _context.DepartmentCriteriaGroups
                .Select(x => new DepartmentCriteriaGroupDto
                {
                    Id = x.Id,
                    CriteriaGroupId = x.CriteriaGroupId,
                    Weightage = x.Weightage,
                    DepartmentId = x.DepartmentId,
                   
                    //  WeightageCount = x.Weightages+ x.WeightageCount
                })
                .ToListAsync();

            return departmentCriteriaGroup;
        }

        public async Task<string> DeleteDepartmentCriteriaGroupAsync(Guid id)
        {
            var criteriaGroup = await _context.DepartmentCriteriaGroups.FirstOrDefaultAsync(x => x.Id == id);

            if (criteriaGroup != null)
            {
                _context.Remove(criteriaGroup);
                await _context.SaveChangesAsync();
                return "Criteria group deleted successfully";
            }

            return "Criteria group delete failed";
        }

        public Task<DepartmentCriteriaGroupDto> GetDepartmentCriteriaGroupByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DepartmentCriteriaGroupDto>> GetCriteriaGroupByDepartmentAsync(Guid departmentId)
        {
            var CriteriaGroupList = await _context.DepartmentCriteriaGroups.Include(x => x.CriteriaGroup).Where(x => x.DepartmentId == departmentId)
                 .Select(x => new DepartmentCriteriaGroupDto
                 {
                     Id = x.Id,
                     Weightage = x.Weightage,
                     DepartmentId = x.DepartmentId,
                     CriteriaGroupId = x.CriteriaGroupId,
                     Name = x.CriteriaGroup.Name,
                     //totalWeightage = x.totalWeightage
                 })
                .ToListAsync();

            return CriteriaGroupList;
        }

        public async Task<string> UpdateDepartmentCriteriaGroupAsync(DepartmentCriteriaGroupDto departmentCriteriaGroupDto)
        {
            var departmentCriteria = await _context.DepartmentCriteriaGroups.FirstOrDefaultAsync(x => x.Id == departmentCriteriaGroupDto.Id);

            if (departmentCriteria.Id != null)
            {
                departmentCriteria.CriteriaGroupId = departmentCriteriaGroupDto.CriteriaGroupId;
                departmentCriteria.Weightage = departmentCriteriaGroupDto.Weightage;
                departmentCriteria.DepartmentId = departmentCriteriaGroupDto.DepartmentId;


                await _context.SaveChangesAsync();
                return "Department criteria update success...!";
            }

            return "Department criteria not update...!";
        }

        public async Task<int> Totalweightages(Guid id)
        {
            var totalWeightage = _context.DepartmentCriteriaGroups.Where(x => x.DepartmentId == id).Sum(x=>x.Weightage);

            return totalWeightage;
        }
    }
}
