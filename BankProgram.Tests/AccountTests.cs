namespace BankProgram.Tests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Deposit_AddsAmountToBalance()
        {
            // Arrange
            Account account = new IndividualCheckingAccount("John Doe");

            // Act
            account.Deposit(500);

            // Assert
            Assert.AreEqual(500, account.Balance);
        }

        [TestMethod]
        public void Withdraw_SubtractsAmountFromBalance()
        {
            // Arrange
            Account account = new IndividualCheckingAccount("John Doe");
            account.Deposit(1000);

            // Act
            account.Withdraw(500);

            // Assert
            Assert.AreEqual(500, account.Balance);
        }

        [TestMethod]
        public void Withdraw_ThrowsExceptionWhenAmountExceedsIndividualCheckingLimit()
        {
            // Arrange
            Account account = new IndividualCheckingAccount("John Doe");
            account.Deposit(1000);

            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => account.Withdraw(1500));
        }

        [TestMethod]
        public void Transfer_MovesAmountBetweenAccounts()
        {
            // Arrange
            Account sourceAccount = new IndividualCheckingAccount("John Doe");
            Account destinationAccount = new SavingsAccount("Jane Smith");
            sourceAccount.Deposit(1000);

            // Act
            sourceAccount.Transfer(destinationAccount, 500);

            // Assert
            Assert.AreEqual(500, sourceAccount.Balance);
            Assert.AreEqual(500, destinationAccount.Balance);
        }

        [TestMethod]
        public void Transfer_ThrowsExceptionWhenInsufficientFunds()
        {
            // Arrange
            Account sourceAccount = new IndividualCheckingAccount("John Doe");
            Account destinationAccount = new SavingsAccount("Jane Smith");
            sourceAccount.Deposit(500);

            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => sourceAccount.Transfer(destinationAccount, 1000));
        }
    }
}
