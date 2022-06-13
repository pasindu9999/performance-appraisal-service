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
                Name = teamDto.Name,
                DepartmentId = teamDto.DepartmentId,
                Description = teamDto.Description,
                NoOfEmployees = teamDto.NoOfEmployees,
                TeamLeaderId = teamDto.TeamLeaderId
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
                    Name = x.Name,
                    DepartmentId = x.DepartmentId,
                    Description = x.Description,
                    NoOfEmployees = x.NoOfEmployees,
                    DepartmentName = x.Department.Name,
                    TeamLeaderId = (Guid)x.TeamLeaderId,
                    TeamLeaderFirstName = x.TeamLeader.FirstName
                })
                .ToListAsync();

            return teamsList;
        }


        //filter according to the departments
        public Task<List<TeamDto>> GetTeamsbyDepartmentAsync(Guid departmentId)
        {
            var teamsList =  _context.Teams.Include(x => x.Department).Where(x=> x.DepartmentId== departmentId)
                .Select(x => new TeamDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    DepartmentId = x.DepartmentId,
                    Description = x.Description,
                    NoOfEmployees = x.NoOfEmployees,
                    TeamLeaderId = (Guid)x.TeamLeaderId
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
                    Name = x.Name,
                    DepartmentId = x.DepartmentId,
                    Description = x.Description,
                    NoOfEmployees = x.NoOfEmployees,
                    TeamLeaderId = (Guid)x.TeamLeaderId
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return team;
        }

        public async Task<string> UpdateTeamAsync(TeamDto teamDto)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == teamDto.Id);

            if (team.Id != null)
            {
                team.Name = team.Name;
                team.DepartmentId = teamDto.DepartmentId;
                team.TeamLeaderId = teamDto.TeamLeaderId;
                team.Description = teamDto.Description;
                team.NoOfEmployees = teamDto.NoOfEmployees;

                await _context.SaveChangesAsync();
                return "Team update success...!";
            }

            return "Team not update...!";
        }

        public async Task<string> DeleteTeamAsync(Guid id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);

            if (team != null)
            {
                _context.Remove(team);
                await _context.SaveChangesAsync();
                return "Team delete sucessful";
            }

            return "Team can not delete";
        }

     
    }
}
