using GDNET.Domain.Entities.System;
using GDNET.Framework.Base;
using GDNET.Framework.DataAnnotations;

namespace GDNET.WebInfrastructure.Models.System
{
    public class UserDetailsModel : AbstractViewModel<User>
    {
        #region Properties

        [DisplayNameML("GUI.User.Email")]
        public string Email { get; set; }

        [DisplayNameML("GUI.User.DisplayName")]
        public string DisplayName { get; set; }

        [DisplayNameML("GUI.User.Introduction")]
        public string Introduction { get; set; }

        [DisplayNameML("GUI.User.TotalPoints")]
        public double TotalPoints
        {
            get;
            private set;
        }

        public UserDetailsMode DisplayMode
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public UserDetailsModel()
            : base()
        {
        }

        public override void Initialize(User entity, bool filterActiveOnly)
        {
            base.Id = entity.Id.ToString();
            this.DisplayName = entity.DisplayName;
            this.Introduction = entity.Introduction;
            this.Email = entity.Email;
            this.TotalPoints = entity.TotalPoints;

            base.InitializeCommon(entity);
        }

        #endregion
    }
}
