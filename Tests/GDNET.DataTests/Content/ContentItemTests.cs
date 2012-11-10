using GDNET.DataTests.Base;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories;
using NUnit.Framework;

namespace GDNET.DataTests.Content
{
    [TestFixture]
    public class ContentItemTests : NUnitTestBase
    {
        [Test]
        public void CanAddContentItem()
        {
            var c1 = ContentItem.Factory.Create("C1", true);
            var c2 = ContentItem.Factory.Create("C2", false);
            c2.Description = "D2";
            c2.Keywords = "K2";

            DomainRepositories.ContentItem.Save(c1);
            DomainRepositories.ContentItem.Save(c2);
            DomainRepositories.RepositoryStrategy.FlushAndClear();

            var listOfContentItems = DomainRepositories.ContentItem.GetAll();
            Assert.AreEqual(2, listOfContentItems.Count);
            Assert.AreEqual(true, listOfContentItems[0].IsActive);
            Assert.AreEqual(false, listOfContentItems[1].IsActive);
            Assert.AreEqual("C1", listOfContentItems[0].Name);
            Assert.AreEqual("C2", listOfContentItems[1].Name);
            Assert.AreEqual(null, listOfContentItems[0].Description);
            Assert.AreEqual("D2", listOfContentItems[1].Description);
            Assert.AreEqual(null, listOfContentItems[0].Keywords);
            Assert.AreEqual("K2", listOfContentItems[1].Keywords);

            listOfContentItems[0].Description = "D1";
            DomainRepositories.RepositoryStrategy.FlushAndClear();

            listOfContentItems = DomainRepositories.ContentItem.GetAll();
            Assert.AreEqual("D1", listOfContentItems[0].Description);
        }

        [Test]
        public void CanAddContentItemWithLog()
        {
            var c1 = ContentItem.Factory.Create("C1", true);
            DomainRepositories.ContentItem.Save(c1);

            c1.AddLogCreation();
            DomainRepositories.RepositoryStrategy.FlushAndClear();

            var listOfContentItems = DomainRepositories.ContentItem.GetAll();
            Assert.AreEqual(1, listOfContentItems[0].Logs.Count);
        }

        [Test]
        public void CanAddContentItemWithManyLogs()
        {
            var c1 = ContentItem.Factory.Create("C1", true);
            DomainRepositories.ContentItem.Save(c1);

            int max = 1000;
            for (int index = 1; index <= max; index++)
            {
                c1.AddLog("MSG " + index, string.Empty);
            }
            DomainRepositories.RepositoryStrategy.FlushAndClear();

            var listOfContentItems = DomainRepositories.ContentItem.GetAll();
            Assert.AreEqual(max, listOfContentItems[0].Logs.Count);
        }

        [Test]
        public void CanAddContentItemWithParts()
        {
            var c1 = ContentItem.Factory.Create("C1", true);
            DomainRepositories.ContentItem.Save(c1);

            c1.AddPart(ContentPart.Factory.Create("P1", "D1", true));
            c1.AddPart(ContentPart.Factory.Create("P2", "D2", false));
            DomainRepositories.RepositoryStrategy.FlushAndClear();

            var listOfContentItems = DomainRepositories.ContentItem.GetAll();
            Assert.AreEqual(2, listOfContentItems[0].Parts.Count);
            Assert.AreEqual("P1", listOfContentItems[0].Parts[0].Name);
            Assert.AreEqual("P2", listOfContentItems[0].Parts[1].Name);
            Assert.AreEqual("D1", listOfContentItems[0].Parts[0].Details);
            Assert.AreEqual("D2", listOfContentItems[0].Parts[1].Details);
            Assert.AreEqual(true, listOfContentItems[0].Parts[0].IsActive);
            Assert.AreEqual(false, listOfContentItems[0].Parts[1].IsActive);
        }

        [Test]
        public void CanMoveParts()
        {
            var c1 = ContentItem.Factory.Create("C1", true);
            DomainRepositories.ContentItem.Save(c1);

            c1.AddPart(ContentPart.Factory.Create("P1", "D1", true));
            c1.AddPart(ContentPart.Factory.Create("P2", "D2", false));
            DomainRepositories.RepositoryStrategy.FlushAndClear();

            var listOfContentItems = DomainRepositories.ContentItem.GetAll();
            Assert.AreEqual(2, listOfContentItems[0].Parts.Count);
            Assert.AreEqual("P1", listOfContentItems[0].Parts[0].Name);
            Assert.AreEqual("P2", listOfContentItems[0].Parts[1].Name);

            listOfContentItems[0].MoveUpPartById(listOfContentItems[0].Parts[1].Id);
            DomainRepositories.RepositoryStrategy.FlushAndClear();

            listOfContentItems = DomainRepositories.ContentItem.GetAll();
            Assert.AreEqual("P2", listOfContentItems[0].Parts[0].Name);
            Assert.AreEqual("P1", listOfContentItems[0].Parts[1].Name);

            listOfContentItems[0].MoveDownPartById(listOfContentItems[0].Parts[0].Id);
            DomainRepositories.RepositoryStrategy.FlushAndClear();

            listOfContentItems = DomainRepositories.ContentItem.GetAll();
            Assert.AreEqual("P1", listOfContentItems[0].Parts[0].Name);
            Assert.AreEqual("P2", listOfContentItems[0].Parts[1].Name);
        }

        [Test]
        public void CanAddLog()
        {
            var content0 = ContentItem.Factory.Create("The content 1", true);
            content0.AddLogCreation();

            DomainRepositories.ContentItem.Save(content0);
            DomainRepositories.RepositoryStrategy.FlushAndClear();

            var content1 = DomainRepositories.ContentItem.GetById(content0.Id);
            Assert.IsNotNull(content1.LastLog);
            Assert.AreEqual(1, content1.Logs.Count);
        }
    }
}
