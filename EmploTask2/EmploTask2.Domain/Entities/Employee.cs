namespace EmploTask2.Domain.Entities
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int TeamId { get; private set; }
        public virtual Team Team { get; private set; }
        public int VacationPackageId { get; private set; }
        public virtual VacationPackage VacationPackage { get; private set; }
        public virtual ICollection<Vacation> Vacations { get; private set; } = [];
        
        public int UsedVacationDays { get; private set; }

        private Employee()
        {
        }

        public Employee(string name, int teamId, int vacationPackageId)
        {
            Name = name;
            TeamId = teamId;
            VacationPackageId = vacationPackageId;
        }

        public Employee(int id, string name, int teamId, int vacationPackageId)
        {
            Id = id;
            Name = name;
            TeamId = teamId;
            VacationPackageId = vacationPackageId;
        }

        public Employee(int id, string name, int teamId, int vacationPackageId, int usedVacationDays)
        {
            Id = id;
            Name = name;
            TeamId = teamId;
            VacationPackageId = vacationPackageId;
            UsedVacationDays = usedVacationDays;
        }
    }
}