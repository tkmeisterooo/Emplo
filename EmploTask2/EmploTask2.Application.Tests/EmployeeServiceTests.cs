using EmploTask2.Application.Services;
using EmploTask2.Domain.Entities;

namespace EmploTask2.Application.Tests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private Employee _employee = null!;
        private VacationPackage _vacationPackage = null!;
        private VacationPackage _vacationSmallPackage = null!;
        private List<Vacation> _vacations = null!;
        private EmployeeService _service = null!;


        [SetUp]
        public void Setup()
        {
            _employee = new Employee(1, "John Doe", 1, 1);
            _vacationPackage = new VacationPackage(1, "Standard Package", 20, 2025); // 160 hours 
            _vacationSmallPackage = new VacationPackage(1, "Small Package", 10, 2025); // 80 hours
            _vacations = new List<Vacation>
            {
                new Vacation(1, DateTime.Now, DateTime.Now, 8, 0), // 1 day
                new Vacation(1, DateTime.Now, DateTime.Now.AddDays(1), 16, 1), // 2 days
                new Vacation(1, DateTime.Now, DateTime.Now.AddDays(2), 24, 1), // 3 days
                new Vacation(1, DateTime.Now, DateTime.Now.AddDays(3), 32, 1), // 4 days
            };

            _service = new EmployeeService();
        }


        [Test]
        public void employee_can_request_vacation()
        {
            var canRequestVacation = _service.IfEmployeeCanRequestVacation(_employee, _vacations, _vacationPackage);
            Assert.That(canRequestVacation, Is.True, "Employee should be able to request vacation.");


        }
        [Test]
        public void employee_cant_request_vacation()
        {
            var canRequestVacation = _service.IfEmployeeCanRequestVacation(_employee, _vacations, _vacationSmallPackage);
            Assert.That(canRequestVacation, Is.False, "Employee should not be able to request vacation.");
        }

    }
}