using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Roles
{
    public static class RoleEfCoreQueryableExtensions
    {
        public static IQueryable<Role> IncludeDetails(this IQueryable<Role> queryable, bool include = true)
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