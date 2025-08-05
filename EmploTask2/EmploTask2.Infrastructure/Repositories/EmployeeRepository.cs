using EmploTask2.Domain.Abstractions.Repositories;
using EmploTask2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmploTask2.Infrastructure.Repositories;

public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
{
    private const int HoursPerDay = 8;

    public async Task<List<Employee>> GetEmployeesFromTeamDotNetWithHolidayRequestIn2019Year()
    {
        return await dbContext.Employees.Where(e => e.Team.Name == ".NET" &&
            e.Vacations.Any(v => v.DateSince.Year == 2019 || v.DateUntil.Year == 2019))
            .ToListAsync();
    }

    public async Task<List<Employee>> GetEmployeesWithCountedDaysUsedInCurrentYear()
    {
        DateTime now = DateTime.Now;
        int currentYear = now.Year;

        return await dbContext.Employees
            .Where(e => e.Vacations.Any(v => v.DateSince.Year == currentYear &&
                v.DateSince.Date < now.Date &&
                v.DateUntil.Year == currentYear &&
                v.DateUntil.Date < DateTime.Now.Date)
            )
            .Select(e => new Employee(e.Id, e.Name, e.TeamId, e.VacationPackageId, e.Vacations.Sum(item => item.NumberOfHours) / HoursPerDay))
            .ToListAsync();
    }

}