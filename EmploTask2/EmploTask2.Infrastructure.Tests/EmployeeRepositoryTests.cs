using EmploTask2.Domain.Entities;
using EmploTask2.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmploTask2.Infrastructure.Tests
{
    [TestFixture]
    public class Tests
    {
        private AppDbContext _context = null!;
        private EmployeeRepository _repository = null!;

        [SetUp]
        public async Task SetUp()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);

            var team1 = new Team(1, ".NET");
            var team2 = new Team(2, "React");

            // only employee1 should be returned in the first test
            var employee1 = new Employee("Jan Nowak", team1.Id, 1); // Team .NET, should be returned in the first test
            employee1.Vacations.Add(new Vacation(1, new DateTime(2019, 5, 1), new DateTime(2019, 5, 3), 24, 0)); // 3 days vacation in 2019

            var employee2 = new Employee("Adam Kowalski", team1.Id, 2); // Same team as employee1, should not be returned in the first test cuz its from 2025
            employee2.Vacations.Add(new Vacation(2, new DateTime(2025, 6, 10), new DateTime(2025, 6, 12), 24, 0)); // 3 days vacation in 2025

            // only employee3 should be returned from second test, and also should have 3 days vacation counted
            var employee3 = new Employee("Ewa Zieliñska", team2.Id, 3); // Different team, should not be returned in the first test
            employee3.Vacations.Add(new Vacation(3, new DateTime(2019, 7, 15), new DateTime(2019, 7, 17), 24, 0)); // 3 days vacation in 2019

            await _context.Teams.AddRangeAsync(team1, team2);
            await _context.Employees.AddRangeAsync(employee1, employee2, employee3);
            await _context.SaveChangesAsync();

            _repository = new EmployeeRepository(_context);
        }

        [Test]
        public async Task GetEmployeesFromTeamDotNetWithHolidayRequestIn2019Year_ReturnsCorrectEmployees()
        {
            var result = await _repository.GetEmployeesFromTeamDotNetWithHolidayRequestIn2019Year();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result.Select(e => e.Name), Does.Contain("Jan Nowak"));
        }

        [Test]
        public async Task GetEmployeesWithCountedDaysUsedInCurrentYear_ReturnsEmployeesWithVacationCount()
        {
            var result = await _repository.GetEmployeesWithCountedDaysUsedInCurrentYear();
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].UsedVacationDays, Is.EqualTo(3));
        }




        [TearDown]
        public void TearDown()
        {
            _context?.Dispose();
        }
    }
}