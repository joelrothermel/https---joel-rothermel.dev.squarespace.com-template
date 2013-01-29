using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CNM.Tests
{
    [TestClass]
    public class EncryptorTests
    {
        [TestMethod]
        public void CanCompute()
        {
            string result = new Encryptor().Encrypt("12345");
            Assert.AreEqual("foo", result);
        }
    }
}
