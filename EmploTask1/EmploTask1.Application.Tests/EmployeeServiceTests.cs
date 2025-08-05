using EmploTask1.Application.Services;
using EmploTask1.Domain.Entities;

namespace EmploTask1.Application.Tests
{
    public class Tests
    {
        private EmployeeService _employeeService;
        private List<Employee> _employeeList;

        [SetUp]
        public void Setup()
        {
            var employee1 = new Employee { Id = 1, Name = "Jan Kowalski", SuperiorId = null };
            var employee2 = new Employee { Id = 2, Name = "Kamil Nowak", SuperiorId = 1 };
            var employee3 = new Employee { Id = 3, Name = "Anna Mariacka", SuperiorId = 1 };
            var employee4 = new Employee { Id = 4, Name = "Andrzej Abacki", SuperiorId = 2 };
            var employee5 = new Employee { Id = 5, Name = "Mariano Italiano", SuperiorId = 4 };

            _employeeList =
            [
                employee1,
                employee2,
                employee3,
                employee4,
                employee5
            ];

            _employeeService = new EmployeeService();
        }

        [Test]
        public void EmployeeStructureTestFilling()
        {

            var employeeStructure = _employeeService.FillEmployeesStructure(_employeeList);
            var row1 = _employeeService.GetSuperiorRowOfEmployee(2, 1); // row1 = 1
            var row2 = _employeeService.GetSuperiorRowOfEmployee(4, 3); // row2 = null
            var row3 = _employeeService.GetSuperiorRowOfEmployee(4, 1); // row3 = 2

            Assert.Multiple(() =>
            {
                Assert.That(row1, Is.EqualTo(1), "Row of employee 2 with superior 1 should be 1");
                Assert.That(row2, Is.Null, "Row of employee 4 with superior 3 should be null");
                Assert.That(row3, Is.EqualTo(2), "Row of employee 4 with superior 1 should be 2");
            });
        }
    }
}