using System;
using MyProject.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MyProject.Roles
{
    public class RoleRepository : EfCoreRepository<MyProjectDbContext, Role, Guid>, IRoleRepository
    {
        public RoleRepository(IDbContextProvider<MyProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}