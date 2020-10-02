using System;
using MyProject.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MyProject.Users
{
    public class UserRepository : EfCoreRepository<MyProjectDbContext, User, Guid>, IUserRepository
    {
        public UserRepository(IDbContextProvider<MyProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}