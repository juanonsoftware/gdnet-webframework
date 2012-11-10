using System;
using GDNET.Base;
using GDNET.Domain.Entities.System;
using GDNET.Mapping.Base;
using GDNET.Mapping.Common;
using GDNET.NHibernate.Mapping;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.System
{
    public class UserMapping : AbstractJoinedSubclassMapping<User, Guid>, IEntityMapping
    {
        public UserMapping()
            : base()
        {
            var defaultUser = default(User);
            var defaultEmployee = default(Employee);
            var pis = typeof(Employee).GetMember(ExpressionAssistant.GetPropertyName(() => defaultEmployee.User));

            base.Property(e => e.Email, m =>
            {
                m.Unique(true);
            });
            base.Property(e => e.Password, m =>
            {
                m.NotNullable(true);
            });
            base.Property(e => e.DisplayName);
            base.Property(e => e.Introduction);
            base.Property(e => e.TotalPoints);
            base.Property(e => e.IsGuest);
            base.Property(e => e.IsRoot);

            base.ManyToOne(e => e.Language, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Access(Accessor.Property);
                m.Cascade(Cascade.None);
                m.Column(MappingAssistant.GetForeignKeyColumn(() => defaultUser.Language));
            });

            base.OneToOne(e => e.Employee, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Access(Accessor.Property);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.PropertyReference(pis[0]);
            });
        }
    }
}
