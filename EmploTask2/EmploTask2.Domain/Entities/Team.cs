
namespace EmploTask2.Domain.Entities
{
    public class Team
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public virtual ICollection<Employee> Employees { get; private set; } = [];

        private Team()
        {
        }

        public Team(string name)
        {
            Name = name;
        }

        public Team(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Team(int id, string name, ICollection<Employee> employees)
        {
            Id = id;
            Name = name;
            Employees = employees;
        }
    }
}