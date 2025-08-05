namespace EmploTask2.Domain.Entities
{
    public class Vacation
    {
        public int Id { get; private set; }
        public DateTime DateSince { get; private set; }
        public DateTime DateUntil { get; private set; }
        public int NumberOfHours { get; private set; }
        public int IsPartialVacation { get; private set; }
        public int EmployeeId { get; private set; }
        public virtual Employee Employee { get; private set; }

        private Vacation()
        {
        }

        public Vacation(int employeeId, DateTime dateSince, DateTime dateUntil, int numberOfHours, int isPartialVacation)
        {
            EmployeeId = employeeId;
            DateSince = dateSince;
            DateUntil = dateUntil;
            NumberOfHours = numberOfHours;
            IsPartialVacation = isPartialVacation;
        }
    }
}