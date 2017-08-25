using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnyExtend;

namespace UnitTest.AnyExtend
{
    [TestClass]
    public class DateExtTest : BaseTest
    {
        [TestMethod]
        public void Between()
        {
            DateTime dt = DateTime.Now;
            DateTime? t1 = null;
            DateTime? t2 = dt.AddDays(1);

            Assert.AreEqual(dt.Between(t1, t2), true);
        }
    }
}