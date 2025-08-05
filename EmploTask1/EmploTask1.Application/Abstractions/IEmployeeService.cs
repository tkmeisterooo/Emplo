using EmploTask1.Domain.Entities;

namespace EmploTask1.Application.Abstractions
{
    public interface IEmployeeService
    {
        List<EmployeeStructure> FillEmployeesStructure(List<Employee> employees);
        int? GetSuperiorRowOfEmployee(int employeeId, int superiorId);
    }
}