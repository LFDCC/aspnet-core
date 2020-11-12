using Volo.Abp.AuditLogging;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace MyProject
{
    [DependsOn(
        typeof(MyProjectDomainSharedModule)  ,
        typeof(AbpAuditLoggingDomainModule),
        typeof(AbpPermissionManagementDomainModule)
    )]
    public class MyProjectDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionManagementOptions>(options =>
            {
                //TODO: Can we prevent duplication of permission names without breaking the design and making the system complicated
                options.ProviderPolicies[UserPermissionValueProvider.ProviderName] = "MyProject.User.ManagePermissions";
                options.ProviderPolicies[RolePermissionValueProvider.ProviderName] = "MyProject.Role.ManagePermissions";
            });
        }
    }
}
