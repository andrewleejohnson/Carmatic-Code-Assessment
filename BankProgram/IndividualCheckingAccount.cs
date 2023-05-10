
namespace BankProgram
{
    public class IndividualCheckingAccount : CheckingAccount
    {
        public IndividualCheckingAccount(string owner) : base(owner)
        {
        }

        public override void Withdraw(decimal amount)
        {
            if (amount > 1000)
            {
                throw new InvalidOperationException("Withdrawal amount exceeds the limit for Individual Checking account.");
            }

            base.Withdraw(amount);
        }
    }
}
