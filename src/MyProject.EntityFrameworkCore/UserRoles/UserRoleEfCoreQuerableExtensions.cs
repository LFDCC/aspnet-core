using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyProject.UserRoles
{
    public static class UserRoleEfCoreQueryableExtensions
    {
        public static IQueryable<UserRole> IncludeDetails(this IQueryable<UserRole> queryable, bool include = true)
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