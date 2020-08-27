using BankingDomain;
using System;
using Xunit;

namespace BankingTests
{

    public class UnitTest1
    {
        public UnitTest1()
        {
            // do you initialization here.
        }

        [Fact]

        public void Multiply()
        {
            // Given / Arrange
            // - You create a brand new everything.
            // - No unit test can depend on any other unit test running first, etc.
            // When / Act
            // - You poke at it. You make it do something.
            // Then / Assert
            // - You observe the effects of poking at it.
            // - OR you observe it's interactions with other code.
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(4, 4);
        }

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(10, 5, 15)]
        [InlineData(40, 2, 42)]
        public void CanAddTwoIntegers(int a, int b, int expected)
        {
            var answer = a + b;
            Assert.Equal(expected, answer);
        }

        [Fact]
        public void DoesItActuallyWork()
        {
           // var account = new BankAccount(new CutoffBonusCalculator(new StandardCutoffClock(new SystemTime())), )
        }
    }
}
