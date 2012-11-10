using System;
using System.Web.Security;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;
using GDNET.Domain.Services;

namespace GDNET.WebInfrastructure.Security
{
    public class NHibernateMembershipProvider : MembershipProvider
    {
        public override string ApplicationName
        {
            get;
            set;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            User user = DomainRepositories.User.FindByEmail(username);
            return (user == null) ? false : user.ChangePassword(oldPassword, newPassword);
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            status = MembershipCreateStatus.UserRejected;

            MembershipUser membershipUser = null;
            User newUser = User.Factory.Create(email, password);
            newUser.IsActive = true;

            if (DomainRepositories.User.Save(newUser))
            {
                membershipUser = this.GetUser(email, true);
                status = MembershipCreateStatus.Success;
            }

            return membershipUser;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { return true; }
        }

        public override bool EnablePasswordRetrieval
        {
            get { return true; }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            MembershipUser membershipUser = null;
            User user = DomainRepositories.User.FindByEmail(username);

            if (user != null)
            {
                DateTime creationDate = DateTime.Now;
                DateTime lastLoginDate = DateTime.Now;
                DateTime lastActivityDate = DateTime.Now;
                DateTime lastPasswordChanged = DateTime.Now;
                DateTime lastLockoutDate = DateTime.Now;
                membershipUser = new MembershipUser(this.GetType().Name, user.Email, user.Id, user.Email, string.Empty, string.Empty, true, false, creationDate, lastLoginDate, lastActivityDate, lastPasswordChanged, lastLockoutDate);
            }

            return membershipUser;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            User user = DomainRepositories.User.FindByEmail(email);
            return (user == null) ? string.Empty : user.Email;
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 10; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 10; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return MembershipPasswordFormat.Clear; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return true; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            User user = DomainRepositories.User.FindByEmail(username);
            if ((user != null) && user.IsActive && !user.IsGuest)
            {
                return (DomainServices.Encryption.Decrypt(user.Password) == password);
            }

            return false;
        }
    }
}
