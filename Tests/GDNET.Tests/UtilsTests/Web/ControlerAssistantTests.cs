using System;
using System.Web.Mvc;
using GDNET.WebInfrastructure.Controllers.Extensions;
using NUnit.Framework;

namespace GDNET.Tests.UtilsTests.Web
{
    [TestFixture]
    public class ControlerAssistantTests
    {
        private class XController : Controller { }
        private class X2 : XController
        {
            public ActionResult A1() { throw new NotImplementedException(); }
        }

        [Test]
        public void CanGetControllerName()
        {
            var name = ControllerAssistant.GetControllerName(typeof(XController));
            Assert.AreEqual("X", name);

            name = ControllerAssistant.GetControllerName(typeof(X2));
            Assert.AreEqual("X2", name);
        }

        [Test]
        public void CanGetActionName()
        {
            var x2 = default(X2);
            string name = ControllerAssistant.GetActionName(() => x2.A1());
            Assert.AreEqual("A1", name);
        }
    }
}
