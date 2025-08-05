using EmploTask2.Application.Abstractions;
using EmploTask2.Domain.Abstractions.Repositories;
using EmploTask2.Domain.Entities;

namespace EmploTask2.Application.Services;

public class EmployeeService : IEmployeeService
{
    private const int HoursPerDay = 8;

    public int CountFreeDaysForEmployee(Employee employee, List<Vacation> vacations, VacationPackage vacationPackage)
    {
        var currentYear = DateTime.Now.Year;

        if (vacationPackage.Year != currentYear)
        {
            throw new ArgumentException("Vacation package year does not match the current year.");
        }

        if (employee.VacationPackageId != vacationPackage.Id)
        {
            throw new ArgumentException("Employee's vacation package does not match the provided vacation package.");
        }

        var usedVacationDays = vacations
            .FindAll(item => item.EmployeeId == employee.Id && item.DateSince.Year == currentYear &&
                             item.DateUntil.Year == currentYear).Sum(item => item.NumberOfHours) / HoursPerDay;
        return vacationPackage.GrantedDays - usedVacationDays;
    }

    public bool IfEmployeeCanRequestVacation(Employee employee, List<Vacation> vacations,
        VacationPackage vacationPackage)
    {
        var freeDaysAvailable = CountFreeDaysForEmployee(employee, vacations, vacationPackage);
        return freeDaysAvailable > 0;
    }
}