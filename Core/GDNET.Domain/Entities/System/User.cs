using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GDNET.Domain.Entities.System.Management;
using GDNET.Domain.Services;

namespace GDNET.Domain.Entities.System
{
    public partial class User : EntityHistoryComplex
    {
        private IList<User> connections = new List<User>();

        #region Properties

        public virtual string Email
        {
            get;
            protected set;
        }

        public virtual string DisplayName
        {
            get;
            set;
        }

        public virtual string Introduction
        {
            get;
            set;
        }

        public virtual string Password
        {
            get;
            protected set;
        }

        public virtual double TotalPoints
        {
            get;
            protected set;
        }

        public virtual bool IsGuest
        {
            get;
            protected set;
        }

        public virtual bool IsRoot
        {
            get;
            protected set;
        }

        public virtual Employee Employee
        {
            get;
            set;
        }

        public virtual DataLine Language
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<User> Connections
        {
            get { return new ReadOnlyCollection<User>(this.connections); }
        }

        #endregion

        #region Methods

        public virtual bool ChangePassword(string oldPassword, string newPassword)
        {
            bool result = false;
            if (this.Password == DomainServices.Encryption.Encrypt(oldPassword))
            {
                this.Password = DomainServices.Encryption.Encrypt(newPassword);
                result = true;
            }

            return result;
        }

        public virtual User ToGuest()
        {
            this.IsGuest = true;
            this.IsRoot = false;
            return this;
        }

        public virtual User ToRoot()
        {
            this.IsGuest = false;
            this.IsRoot = true;
            return this;
        }

        public virtual User AddConnection(User aConnection)
        {
            if (!this.connections.Contains(aConnection))
            {
                this.connections.Add(aConnection);
            }

            return this;
        }

        public virtual User AddConnections(IList<User> listOfConnections)
        {
            foreach (var aConnection in listOfConnections)
            {
                this.AddConnection(aConnection);
            }

            return this;
        }

        public virtual User AddConnections(params User[] listOfConnections)
        {
            return this.AddConnections(listOfConnections.ToList());
        }

        public virtual User RemoveConnection(User aConnection)
        {
            if (this.connections.Contains(aConnection))
            {
                this.connections.Remove(aConnection);
            }

            return this;
        }

        public virtual User AddNewPoints(double newPoints)
        {
            this.TotalPoints += newPoints;

            return this;
        }

        #endregion

        internal protected User() { }
    }
}
