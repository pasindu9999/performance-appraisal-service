using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerformanceAppraisalService.Application.Dtos;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Domain.Entities;
using PerformanceAppraisalService.Infrastructure.Data;

namespace PerformanceAppraisalService.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;
        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateTeamAsync(TeamDto teamDto)
        {
            var team = new Team
            {
                RegNo = teamDto.RegNo,
                Name = teamDto.Name,
                DepartmentName = teamDto.DepartmentName,
                Description = teamDto.Description,
                NoOfEmployees = teamDto.NoOfEmployees
            };

            _context.Add(team);
            await _context.SaveChangesAsync();

            return "Team Create success...!";
        }

        public async Task<List<TeamDto>> GetTeamListAsync()
        {
            var teamsList = await _context.Teams
                .Select(x => new TeamDto
                {
                    Id = x.Id,
                    RegNo=x.RegNo,
                    Name = x.Name,
                    DepartmentName = x.DepartmentName,
                    Description = x.Description,
                    NoOfEmployees = x.NoOfEmployees
                })
                .ToListAsync();

            return teamsList;
        }

        public async Task<TeamDto> GetTeamByIdAsync(Guid id)
        {
            var team= await _context.Teams
                .Select(x => new TeamDto
                {
                    Id = x.Id,
                    RegNo = x.RegNo,
                    Name = x.Name,
                    DepartmentName = x.DepartmentName,
                    Description = x.Description,
                    NoOfEmployees = x.NoOfEmployees
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return team;
        }

        public async Task<string> UpdateTeamAsync(TeamDto teamDto)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == teamDto.Id);

            if (team != null)
            {
                team.RegNo = team.RegNo;
                team.Name = team.Name;
                team.DepartmentName = team.DepartmentName;
                team.Description = team.Description;
                team.NoOfEmployees = team.NoOfEmployees;

                await _context.SaveChangesAsync();
                return "Team update success...!";
            }

            return "Team not update...!";
        }

        public async Task<object> DeleteTeamAsync(Guid id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);

            if (team != null)
            {
                _context.Remove(team);
                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }

     
    }
}
