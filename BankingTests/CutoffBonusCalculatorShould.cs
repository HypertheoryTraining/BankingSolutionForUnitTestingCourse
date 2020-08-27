using BankingDomain;
using Moq;
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
            var cutoffStub = new Mock<IProvideTheCutoffClock>();
            cutoffStub.Setup(c => c.IsBeforeCutoff()).Returns(true);
            ICalculateBankAccountBonuses calculator = new CutoffBonusCalculator(cutoffStub.Object);

            var bonus = calculator.GetDepositBonusFor(1000, 100);

            Assert.Equal(10M, bonus);
        }

        [Fact]
        public void GiveNoBonusAfterDailyCutoff()
        {
            var cutoffStub = new Mock<IProvideTheCutoffClock>();
            cutoffStub.Setup(c => c.IsBeforeCutoff()).Returns(false);
            ICalculateBankAccountBonuses calculator = new CutoffBonusCalculator(cutoffStub.Object);

            var bonus = calculator.GetDepositBonusFor(1000, 100);

            Assert.Equal(0M, bonus);
        }
    }

    //public class TestingBonusCalculator : CutoffBonusCalculator
    //{
    //    bool beforeCutoffResponse;

    //    public TestingBonusCalculator(bool beforeCutoffResponse)
    //    {
    //        this.beforeCutoffResponse = beforeCutoffResponse;
    //    }

    //    protected override bool BeforeCutoff()
    //    {
    //        return beforeCutoffResponse;
    //    }
    //}
}
