using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnyExtend;

namespace UnitTest.AnyExtend
{
    [TestClass]
    public class EncodingExtTest : BaseTest
    {
        [TestMethod]
        public void ToBase64Url()
        {
            string str = "dZWFyTA5YTg0dDM0NF+>==";
            string actual = EncodingExt.ToBase64Url(str);
            string expect = "ZFpXRnlUQTVZVGcwZERNME5_Ris-PT0";

            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void FromBase64Url()
        {
            string str = "ZFpXRnlUQTVZVGcwZERNME5_Ris-PT0";
            string actual = EncodingExt.FromBase64Url(str, null);
            string expect = "dZWFyTA5YTg0dDM0NF+>==";

            Assert.AreEqual(expect, actual);
        }
    }
}