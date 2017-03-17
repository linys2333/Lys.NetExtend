using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnyExtend;

namespace UnitTest.AnyExtend
{
    [TestClass]
    public class CryptoExtTest : BaseTest
    {
        [TestMethod]
        public void GetHmacHash()
        {
            string actual = EncodingExt.ToBase64Url(CryptoExt.GetHmacHash("HMACSHA256", "lys", "salt"));
            string actual2 = EncodingExt.ToBase64Url(CryptoExt.GetHmacHash<HMACSHA256>("lys", "salt"));
            string expect = "Liof_mjT4Kd1V7I7ItvcTGO3yBezkbN0UVDHXm7m1Vg";

            Assert.AreEqual(expect, actual);
            Assert.AreEqual(expect, actual2);
        }

        [TestMethod]
        public void GetMd5Hash()
        {
            string actual = CryptoExt.GetMd5Hash("lys", "salt", EncodeType.Hex);
            string expect = "253eb762911ca80042e997d12448b0c6";

            Assert.AreEqual(expect, actual);
        }
    }
}