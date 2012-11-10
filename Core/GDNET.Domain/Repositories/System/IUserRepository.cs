using System;
using GDNET.Base.DomainRepository;
using GDNET.Domain.Entities.System;

namespace GDNET.Domain.Repositories.System
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
        User FindByEmail(string email);
    }
}
