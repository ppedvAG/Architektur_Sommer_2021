using NUnit.Framework;
using System;

namespace Calculator.Test_NUnit
{
    [TestFixture]
    public class CalcTests_NUnit
    {
        [Test]
        public void Sum_1_and_6_results_7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(1, 6);

            //Assert
            Assert.AreEqual(7, result);
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, -4, -5)]
        [TestCase(-4, 10, 6)]
        public void Sum(int a, int b, int expected)
        {
            Calc calc = new Calc();

            int result = calc.Sum(a, b);

            Assert.AreEqual(expected, result);
        }
    }
}
