namespace BankProgram
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(string owner) : base(owner)
        {
        }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public override void Withdraw(decimal amount)
        {
            if (Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            Balance -= amount;
        }

        public override void Transfer(Account destinationAccount, decimal amount)
        {
            Withdraw(amount);
            destinationAccount.Deposit(amount);
        }
    }
}
