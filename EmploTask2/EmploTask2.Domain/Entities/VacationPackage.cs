namespace EmploTask2.Domain.Entities
{
    public class VacationPackage
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int GrantedDays { get; private set; }
        public int Year { get; private set; }
        public virtual ICollection<Employee> Employees { get; private set; }

        private VacationPackage()
        {
        }

        public VacationPackage(string name, int grantedDays, int year)
        {
            Name = name;
            GrantedDays = grantedDays;
            Year = year;
        }

        public VacationPackage(int id, string name, int grantedDays, int year)
        {
            Id = id;
            Name = name;
            GrantedDays = grantedDays;
            Year = year;
        }
    }
}