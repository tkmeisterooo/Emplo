using EmploTask1.Application.Abstractions;
using EmploTask1.Domain.Entities;

namespace EmploTask1.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<EmployeeStructure> _employeeStructure = [];

        public List<EmployeeStructure> FillEmployeesStructure(List<Employee> employees)
        {
            var employeeDictionary = employees.ToDictionary(e => e.Id);
            foreach (var employee in employees)
            {
                var row = 1;
                var currentEmployee = employee;
                while (currentEmployee.SuperiorId.HasValue)
                {
                    var superiorId = currentEmployee.SuperiorId.Value;
                    _employeeStructure.Add(new EmployeeStructure
                    {
                        EmployeeId = employee.Id,
                        SuperiorId = superiorId,
                        Row = row
                    });

                    if (!employeeDictionary.TryGetValue(superiorId, out currentEmployee))
                    {
                        break;
                    }
                    row++;
                }
            }
            return _employeeStructure;
        }

        public int? GetSuperiorRowOfEmployee(int employeeId, int superiorId)
        {
            return _employeeStructure
                .Where(es => es.EmployeeId == employeeId && es.SuperiorId == superiorId)
                .Select(es => (int?)es.Row)
                .FirstOrDefault();
        }
    }
}
