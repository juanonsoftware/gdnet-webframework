using GDNET.Base;
using NUnit.Framework;

namespace GDNET.Tests.UtilsTests
{
    public interface ITest
    {
        string Signature { get; set; }
    }

    [TestFixture]
    public class ExpressionAssistantTests
    {
        [Test]
        public void CanGetPropertyName()
        {
            var x = default(ITest);
            var s = ExpressionAssistant.GetPropertyName(() => x.Signature);
            Assert.AreEqual("Signature", s);
        }
    }
}
