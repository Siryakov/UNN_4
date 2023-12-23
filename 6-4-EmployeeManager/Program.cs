namespace _6_4_EmployeeManager
{
    public interface IEmployee
    {
        void Work(int hours);
        void TakeBreak(int minutes);
    }

    public class Employee : IEmployee
    {
        public int TotalHoursWorked { get; private set; }
        public int TotalBreakTime { get; private set; }

        public delegate void WorkPerformedEventHandler(int hours);
        public delegate void BreakTakenEventHandler(int minutes);

        public event WorkPerformedEventHandler WorkPerformed;
        public event BreakTakenEventHandler BreakTaken;

        public void Work(int hours)
        {
            TotalHoursWorked += hours;
            WorkPerformed?.Invoke(hours);
        }

        public void TakeBreak(int minutes)
        {
            TotalBreakTime += minutes;
            BreakTaken?.Invoke(minutes);
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee();
            Employee employee2 = new Employee();

            employee1.WorkPerformed += OnWorkPerformed;
            employee1.BreakTaken += OnBreakTaken;

            employee2.WorkPerformed += OnWorkPerformed;
            employee2.BreakTaken += OnBreakTaken;

            employee1.Work(8);
            employee1.TakeBreak(30);

            employee2.Work(6);
            employee2.TakeBreak(15);
        }

        private static void OnWorkPerformed(int hours)
        {
            Console.WriteLine($"Work performed: {hours} hours");
        }

        private static void OnBreakTaken(int minutes)
        {
            Console.WriteLine($"Break taken: {minutes} minutes");
        }
    }
}
