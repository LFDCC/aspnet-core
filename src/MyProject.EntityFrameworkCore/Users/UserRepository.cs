using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MyProject.EntityFrameworkCore;

using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MyProject.Users
{
    public class UserRepository : EfCoreRepository<MyProjectDbContext, User, Guid>, IUserRepository
    {
        public UserRepository(IDbContextProvider<MyProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IQueryable<User> GetAll()
        {
            return this.Include(u => u.UserRoles).ThenInclude(ur => ur.Role);
        }
    }
}