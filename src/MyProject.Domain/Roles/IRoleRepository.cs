using System;
using Volo.Abp.Domain.Repositories;

namespace MyProject.Roles
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {
    }
}