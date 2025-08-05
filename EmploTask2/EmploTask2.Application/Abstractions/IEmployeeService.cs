using EmploTask2.Domain.Entities;

namespace EmploTask2.Application.Abstractions;

public interface IEmployeeService
{
    bool IfEmployeeCanRequestVacation(Employee employee, List<Vacation> vacations, VacationPackage vacationPackage);
    int CountFreeDaysForEmployee(Employee employee, List<Vacation> vacations, VacationPackage vacationPackage);
}