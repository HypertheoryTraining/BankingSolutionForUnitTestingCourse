﻿using BankingDomain;
using BankingTests.Fakes;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class MakingWithdrawals
    {
        [Fact]
        public void MakingAWithdrawalDecreasesBalance()
        {
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 1M;

            account.Withdraw(amountToWithdraw);

            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }

        [Fact]
        public void NegativeAmountsWithdrawnDoNotAffectBalance()
        {
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdraw(-1);
            }
            catch (ImproperTransactionException)
            {
                // I was expecting that!
            }

            Assert.Equal(openingBalance, account.GetBalance());


        }
        [Fact]
        public void NegativeAmountsThrowAnException()
        {

            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);

            Assert.Throws<ImproperTransactionException>(() =>
            {
                account.Withdraw(-1);
            });

        }
    }
}
