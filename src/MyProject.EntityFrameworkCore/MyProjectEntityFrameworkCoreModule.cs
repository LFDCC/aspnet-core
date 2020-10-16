using MyProject.UserRoles;
using Microsoft.Extensions.DependencyInjection;

using MyProject.Roles;
using MyProject.Users;

using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace MyProject.EntityFrameworkCore
{
    [DependsOn(
        typeof(MyProjectDomainModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule)
        )]
    public class MyProjectEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            MyProjectEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MyProjectDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                //options.AddDefaultRepositories(includeAllEntities: true);
                options.AddRepository<User, UserRepository>();
                options.AddRepository<Role, RoleRepository>();
                options.AddRepository<UserRole, UserRoleRepository>();
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also MyProjectMigrationsDbContextFactory for EF Core tooling. */
                options.UseSqlServer();
            });
        }
    }
}
