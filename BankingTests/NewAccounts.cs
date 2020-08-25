﻿using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace BankingTests
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountsHaveCorrectOpeningBalance()
        {
            // WTCYWYH (Write the code you wish you had)
            // Given
            var account = new BankAccount();

            // When
            decimal balance = account.GetBalance();

            // Then
            Assert.Equal(1000M, balance);
        }
    }
}
