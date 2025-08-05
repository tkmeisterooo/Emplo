using EmploTask2.Domain.Entities;
using EmploTask2.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmploTask2.Infrastructure.Tests
{
    [TestFixture]
    public class TeamRepositoryTests
    {
        private AppDbContext _context = null!;
        private TeamRepository _repository = null!;

        [SetUp]
        public async Task SetUp()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);

            var team1 = new Team(1, ".NET");
            var team2 = new Team(2, "React");

            var employee1 = new Employee("Jan Nowak", team1.Id, 1);
            employee1.Vacations.Add(new Vacation(1, new DateTime(2019, 5, 1), new DateTime(2019, 5, 3), 24, 0));

            var employee2 = new Employee("Adam Kowalski", team1.Id, 2);
            employee2.Vacations.Add(new Vacation(2, new DateTime(2025, 6, 10), new DateTime(2025, 6, 12), 24, 0)); 

            var employee3 = new Employee("Ewa Zielińska", team2.Id, 3);
            employee3.Vacations.Add(new Vacation(3, new DateTime(2019, 7, 15), new DateTime(2019, 7, 17), 24, 0));

            await _context.Teams.AddRangeAsync(team1, team2);
            await _context.Employees.AddRangeAsync(employee1, employee2, employee3);
            await _context.SaveChangesAsync();

            _repository = new TeamRepository(_context);
        }

        [Test]
        public async Task GetTeamsWithEmployeesWithoutVacationsIn2019_ReturnsCorrectTeams()
        {
            var result = await _repository.GetTeamsWithEmployeesWithoutVacationsIn2019();
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Employees, Has.Count.EqualTo(1));
        }


        [TearDown]
        public void TearDown()
        {
            _context?.Dispose();
        }
    }
}
