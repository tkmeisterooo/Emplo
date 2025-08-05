using EmploTask2.Domain.Entities;

namespace EmploTask2.Domain.Abstractions.Repositories;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetEmployeesFromTeamDotNetWithHolidayRequestIn2019Year();
    Task<List<Employee>> GetEmployeesWithCountedDaysUsedInCurrentYear();
}