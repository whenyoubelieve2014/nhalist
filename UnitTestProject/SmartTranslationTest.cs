using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NhaList.Convenience.ExtensionMethods;
using NhaList.Convenience.Types;

namespace UnitTestProject
{
    [TestClass]
    public class SmartTranslationTest
    {
        [TestInitialize]
        public void Init()
        {
            Thread.CurrentThread.CurrentCulture = Conveniently.Culture.ViVn;
            Thread.CurrentThread.CurrentUICulture = Conveniently.Culture.ViVn;
        }

        [TestMethod]
        public void ToSmartStringTest()
        {
            string actual = new DateTime(1990, 1, 1).ToSmartString();
            Assert.AreEqual("01 Tháng Giêng 1990", actual);
        }
    }
}