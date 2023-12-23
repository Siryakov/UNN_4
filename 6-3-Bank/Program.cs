namespace _6_3_Bank
{
    public interface IBankAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        decimal GetBalance();
    }

    public class BankAccount : IBankAccount
    {
        private decimal balance;

        public delegate void OverdraftEventHandler(decimal overdraftAmount);
        public delegate void BalanceChangedEventHandler(decimal newBalance);

        public event OverdraftEventHandler Overdraft;
        public event BalanceChangedEventHandler BalanceChanged;

        public void Deposit(decimal amount)
        {
            balance += amount;
            BalanceChanged?.Invoke(balance);
        }

        public void Withdraw(decimal amount)
        {
            if (balance < amount)
            {
                Overdraft?.Invoke(amount - balance);
            }
            else
            {
                balance -= amount;
                BalanceChanged?.Invoke(balance);
            }
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            account.Overdraft += (overdraftAmount) =>
            {
                Console.WriteLine($"Overdraft of {overdraftAmount} detected.");
            };

            account.BalanceChanged += (newBalance) =>
            {
                Console.WriteLine($"Balance changed to {newBalance}.");
            };

            account.Deposit(1000);
            account.Withdraw(500);
            account.Withdraw(1500);
        }
    }
}