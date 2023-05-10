using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgram
{
    public abstract class Account
    {
        public string Owner { get; }
        public decimal Balance { get; protected set; }

        public Account(string owner)
        {
            Owner = owner;
            Balance = 0;
        }

        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);
        public abstract void Transfer(Account destinationAccount, decimal amount);
    }
}
