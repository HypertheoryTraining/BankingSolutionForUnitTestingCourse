using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class StandardCutoffClockShould
    {
        [Fact]
        public void ReturnTrueBeforeCutoff()
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(1969, 04, 20, 16, 59, 59));
            var clock = new StandardCutoffClock(stubbedClock.Object);

            Assert.True(clock.IsBeforeCutoff());
        }

        [Fact]
        public void ReturnFalseAfterCutoff()
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(1969, 04, 20, 17, 00, 00));
            var clock = new StandardCutoffClock(stubbedClock.Object);

            Assert.False(clock.IsBeforeCutoff());
        }
    }
}
