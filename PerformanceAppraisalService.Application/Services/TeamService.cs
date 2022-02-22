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
                tName = teamDto.tName,
                depName = teamDto.depName,
                tDescription = teamDto.tDescription,
                noOfEmployees = teamDto.noOfEmployees
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
                    tName = x.tName,
                    depName = x.depName,
                    tDescription = x.tDescription,
                    noOfEmployees = x.noOfEmployees
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
                    tName = x.tName,
                    depName = x.depName,
                    tDescription = x.tDescription,
                    noOfEmployees = x.noOfEmployees
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return team;
        }

        public async Task<string> UpdateTeamAsync(TeamDto teamDto)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == teamDto.Id);

            if (team != null)
            {
                team.tName = team.tName;
                team.depName = team.depName;
                team.tDescription = team.tDescription;
                team.noOfEmployees = team.noOfEmployees;

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
