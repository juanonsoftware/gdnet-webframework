using GDNET.DataTests.Base;
using GDNET.Domain.Base.Exceptions;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;
using NUnit.Framework;

namespace GDNET.DataTests.System
{
    [TestFixture]
    public class UserTests : NUnitTestBase
    {
        [Test]
        public void CanAddUser()
        {
            var u1 = User.Factory.Create("love@gmail.com", "A1B2C3");
            u1.DisplayName = "Love";
            u1.IsActive = true;
            DomainRepositories.User.Save(u1);
            DomainRepositories.RepositoryStrategy.FlushAndClear();

            var u2 = DomainRepositories.User.GetById(u1.Id);
            Assert.AreEqual("love@gmail.com", u2.Email);
            Assert.AreNotEqual("A1B2C3", u2.Password);
            Assert.AreEqual("Love", u2.DisplayName);
            Assert.IsTrue(u2.IsActive);

            u2.DisplayName = "DN";
            DomainRepositories.RepositoryStrategy.Flush();
        }

        [Test]
        [ExpectedException(typeof(BusinessException))]
        public void CantAddUserBecauseEmailNotUnique()
        {
            var u1 = User.Factory.Create("love@gmail.com", "A1B2C3");
            DomainRepositories.User.Save(u1);

            var u2 = User.Factory.Create("love@gmail.com", "XYZ");
            DomainRepositories.User.Save(u2);
        }

        [Test]
        [ExpectedException(typeof(BusinessException))]
        public void CantModifyUserBecauseEmailNotUnique()
        {
            var u1 = User.Factory.Create("love1@gmail.com", "A1B2C3");
            var u2 = User.Factory.Create("love2@gmail.com", "XYZ");
            DomainRepositories.User.Save(u1);
            DomainRepositories.User.Save(u2);
        }

        [Test]
        public void CanFindByEmail()
        {
            var u1 = User.Factory.Create("love1@gmail.com", "A1B2C3");
            DomainRepositories.User.Save(u1);
            DomainRepositories.RepositoryStrategy.FlushAndClear();

            var u2 = DomainRepositories.User.FindByEmail(u1.Email);
            Assert.IsNotNull(u2);
            Assert.AreEqual(u1.Id, u2.Id);
        }

        [Test]
        public void CanAddLog()
        {
            var u0 = User.Factory.Create("love0@gmail.com", "A1B2C3");
            u0.AddLogCreation();

            DomainRepositories.User.Save(u0);
            DomainRepositories.RepositoryStrategy.FlushAndClear();

            var u1 = DomainRepositories.User.FindByEmail(u0.Email);
            Assert.IsNotNull(u1.LastLog);
            Assert.AreEqual(1, u1.Logs.Count);
        }

        [Test]
        public void CanAddUserWithEmployee()
        {
            var u0 = User.Factory.Create("love0@gmail.com", "A1B2C3");
            var u1 = User.Factory.Create("love1@gmail.com", "A1B2C3");
            var u2 = User.Factory.Create("love2@gmail.com", "A1B2C3");

            var e1 = Employee.Factory.Create();
            u1.Employee = e1;
            e1.User = u1;

            DomainRepositories.User.Save(u0);
            DomainRepositories.User.Save(u1);
            DomainRepositories.User.Save(u2);

            DomainRepositories.RepositoryStrategy.FlushAndClear();

            u2 = DomainRepositories.User.FindByEmail(u1.Email);
            Assert.IsNotNull(u2.Employee);
            Assert.IsNotNull(u2.Employee.User);
            Assert.AreEqual("love1@gmail.com", u2.Employee.User.Email);
        }
    }
}
