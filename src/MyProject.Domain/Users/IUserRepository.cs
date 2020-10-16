using System;
using System.Linq;
using System.Threading.Tasks;

using Volo.Abp.Domain.Repositories;

namespace MyProject.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        IQueryable<User> GetAll();
    }
}