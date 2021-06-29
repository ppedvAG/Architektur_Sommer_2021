using System;

namespace TDDBank
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal v)
        {
            if (v <= 0)
                throw new ArgumentException();

            Balance += v;
        }

        public void Withdraw(decimal v)
        {
            if (v <= 0)
                throw new ArgumentException();
            if(v>Balance)
                throw new InvalidOperationException();

            Balance -= v;

        }
    }
}
