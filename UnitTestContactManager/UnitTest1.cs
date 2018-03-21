using System;
using ContactManager.Controllers;
using ContactManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestContactManager
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ContactController cc = new ContactController();

            Contact[] c = cc.Get();

            Assert.IsNotNull(c);

         //   Assert.IsTrue(c.Length > 3);

        }
    }
}
