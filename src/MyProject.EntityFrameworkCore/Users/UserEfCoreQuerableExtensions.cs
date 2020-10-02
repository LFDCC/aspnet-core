using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Users
{
    public static class UserEfCoreQueryableExtensions
    {
        public static IQueryable<User> IncludeDetails(this IQueryable<User> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}