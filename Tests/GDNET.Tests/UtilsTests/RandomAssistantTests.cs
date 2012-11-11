using System;
using GDNET.Base.Utils;
using NUnit.Framework;

namespace GDNET.Tests.UtilsTests
{
    [TestFixture]
    public class RandomAssistantTests
    {
        [Test]
        public void CanGenerateEmailAddress()
        {
            var s = RandomAssistant.GenerateEmailAddress(new Random());
            Assert.IsNotEmpty(s);
            Assert.IsTrue(s.Contains("@"));
            Assert.IsTrue(s.Contains("."));
        }
    }
}
