using Microsoft.EntityFrameworkCore;

using MyProject.Roles;
using MyProject.Users;

using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using MyProject.UserRoles;

namespace MyProject.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See MyProjectMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class MyProjectDbContext : AbpDbContext<MyProjectDbContext>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureMyProject();
        }
    }
}
