using MyProject.Permissions;

using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;

namespace MyProject
{
    [DependsOn(
        typeof(MyProjectDomainSharedModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class MyProjectApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpPermissionOptions>(options =>
            {
                options.ValueProviders.Add<RolePermissionValueProvider1>();
            });
        }
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            MyProjectDtoExtensions.Configure();
        }
    }
}
