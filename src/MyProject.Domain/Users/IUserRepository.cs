using System;
using Volo.Abp.Domain.Repositories;

namespace MyProject.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}