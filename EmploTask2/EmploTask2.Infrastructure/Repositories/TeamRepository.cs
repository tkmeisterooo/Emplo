using EmploTask2.Domain.Abstractions.Repositories;
using EmploTask2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmploTask2.Infrastructure.Repositories;

public class TeamRepository(AppDbContext context) : ITeamRepository
{
    public async Task<List<Team>> GetTeamsWithEmployeesWithoutVacationsIn2019()
    {
        return await context.Teams
            .Where(t => t.Employees.Any(e => !e.Vacations.Any(v => v.DateSince.Year == 2019 || v.DateUntil.Year == 2019)))
            .Select(t => new Team(t.Id, t.Name, t.Employees.Where(e => !e.Vacations.Any(v => v.DateSince.Year == 2019 || v.DateUntil.Year == 2019)).ToList()))
            .ToListAsync();

    }
}