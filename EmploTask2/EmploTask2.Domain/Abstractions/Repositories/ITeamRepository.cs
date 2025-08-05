using EmploTask2.Domain.Entities;

namespace EmploTask2.Domain.Abstractions.Repositories;

public interface ITeamRepository
{
    Task<List<Team>> GetTeamsWithEmployeesWithoutVacationsIn2019();
}