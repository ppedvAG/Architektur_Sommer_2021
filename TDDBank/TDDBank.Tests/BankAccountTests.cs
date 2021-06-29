using NUnit.Framework;
using System;

namespace TDDBank.Tests
{
    public class BankAccountTests
    {
        [Test]
        public void New_account_should_have_0_as_balance()
        {
            var ba = new BankAccount();

            Assert.AreEqual(0m, ba.Balance);
        }

        [Test]
        public void can_deposit()
        {
            var ba = new BankAccount();

            ba.Deposit(5m);

            Assert.That(ba.Balance, Is.EqualTo(5m));

            ba.Deposit(7m);

            Assert.That(ba.Balance, Is.EqualTo(12m));
        }

        [Test]
        public void deposit_a_negative_value_or_zero_throws()
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(-3m));

            Assert.Throws<ArgumentException>(() => ba.Deposit(0m));

        }

        [Test]
        public void can_withdraw()
        {
            var ba = new BankAccount();

            ba.Deposit(15m);
            ba.Withdraw(5m);

            Assert.That(ba.Balance, Is.EqualTo(10m));

            ba.Withdraw(7m);

            Assert.That(ba.Balance, Is.EqualTo(3m));
        }

        [Test]
        public void Withdraw_a_negative_value_or_zero_throws()
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Withdraw(-3m));

            Assert.Throws<ArgumentException>(() => ba.Withdraw(0m));

        }

        [Test]
        public void Withdraw_below_zero_as_balancs_throws()
        {
            var ba = new BankAccount();
            
            ba.Deposit(15m);

            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(16m));
        }


    }
}