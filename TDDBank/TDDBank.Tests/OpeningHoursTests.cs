using Microsoft.QualityTools.Testing.Fakes;
using NUnit.Framework;
using System;

namespace TDDBank.Tests
{
    [TestFixture]
    public class OpeningHoursTests
    {
        [Test]
        [TestCase(2021, 6, 28, 10, 30, true)]//mo
        [TestCase(2021, 6, 28, 10, 29, false)]//mo
        [TestCase(2021, 6, 28, 10, 0, false)] //mo
        [TestCase(2021, 6, 28, 18, 59, true)] //mo
        [TestCase(2021, 6, 28, 19, 00, false)] //mo
        [TestCase(2021, 7, 3, 13, 0, true)] //sa
        [TestCase(2021, 7, 3, 16, 0, false)] //sa
        [TestCase(2021, 7, 4, 20, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.AreEqual(result, oh.IsOpen(dt));
        }


        [Test]
        public void IsNowOpen()
        {
            using (ShimsContext.Create())
            {
                var oh = new OpeningHours();

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 06, 28, 12, 0, 0);
                Assert.IsTrue(oh.IsNowOpen());//mo
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 06, 29, 12, 0, 0);
                Assert.IsTrue(oh.IsNowOpen());//di
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 06, 30, 12, 0, 0);
                Assert.IsTrue(oh.IsNowOpen());//mi
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 07, 1, 12, 0, 0);
                Assert.IsTrue(oh.IsNowOpen());//do                           
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 07, 2, 12, 0, 0);
                Assert.IsTrue(oh.IsNowOpen());//fr                           
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 07, 3, 12, 0, 0);
                Assert.IsTrue(oh.IsNowOpen());//sa                           
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 07, 4, 12, 0, 0);
                Assert.IsFalse(oh.IsNowOpen());//so
            }
        }
    }
}
