using System;
using MyProject.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MyProject.UserRoles
{
    public class UserRoleRepository : EfCoreRepository<MyProjectDbContext, UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDbContextProvider<MyProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}