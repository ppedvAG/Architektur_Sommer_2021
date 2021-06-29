using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Sum_3_and_4_results_7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(3, 4);

            //Assert
            Assert.AreEqual(7, result);

        }

        [TestMethod]
        public void Sum_N2_and_4_results_2()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(-2, 4);

            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }

        [TestMethod]
        [TestCategory("Data Driven")]
        [DataRow(1, 2, 3)]
        [DataRow(0, 0, 0)]
        [DataRow(-1, -4, -5)]
        [DataRow(-4, 10, 6)]
        public void Sum(int a, int b, int expected)
        {
            Calc calc = new Calc();

            int result = calc.Sum(a, b);

            Assert.AreEqual(expected, result);
        }
    }
}
