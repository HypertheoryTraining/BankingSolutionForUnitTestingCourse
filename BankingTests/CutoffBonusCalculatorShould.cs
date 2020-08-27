using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class CutoffBonusCalculatorShould
    {
        [Fact]
        public void GiveYouTheBonusBeforeDailyCutoff()
        {
            ICalculateBankAccountBonuses calculator = new TestingBonusCalculator(true);

            var bonus = calculator.GetDepositBonusFor(1000, 100);

            Assert.Equal(10M, bonus);
        }

        [Fact]
        public void GiveNoBonusAfterDailyCutoff()
        {
            ICalculateBankAccountBonuses calculator = new TestingBonusCalculator(false);

            var bonus = calculator.GetDepositBonusFor(1000, 100);

            Assert.Equal(0M, bonus);
        }
    }

    public class TestingBonusCalculator : CutoffBonusCalculator
    {
        bool beforeCutoffResponse;

        public TestingBonusCalculator(bool beforeCutoffResponse)
        {
            this.beforeCutoffResponse = beforeCutoffResponse;
        }

        protected override bool BeforeCutoff()
        {
            return beforeCutoffResponse;
        }
    }
}
