using GDNET.DataTests.Base;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;
using NUnit.Framework;

namespace GDNET.DataTests.System
{
    [TestFixture]
    public class DictionaryTests : NUnitTestBase
    {
        [Test]
        public void CanAddTranslation()
        {
            Translation translation = Translation.Factory.Create("K1", "vi-VN", "The Key One");
            DomainRepositories.Translation.Save(translation);
        }
    }
}
