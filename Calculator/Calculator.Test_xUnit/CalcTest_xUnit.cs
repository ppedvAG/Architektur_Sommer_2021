using System;
using Xunit;

namespace Calculator.Test_xUnit
{
    public class CalcTest_xUnit
    {
        [Fact]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }

        [Theory]
        [Trait("Data Driven","")]
        [InlineData(1, 2, 3)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -4, -5)]
        [InlineData(-4, 10, 6)]
        public void Sum(int a, int b, int expected)
        {
            Calc calc = new Calc();

            int result = calc.Sum(a, b);

            Assert.Equal(expected, result);
        }
    }
}
