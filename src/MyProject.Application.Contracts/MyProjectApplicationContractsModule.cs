using Volo.Abp.Account;
using Volo.Abp.Auditing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace MyProject
{
    [DependsOn(
        typeof(MyProjectDomainSharedModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class MyProjectApplicationContractsModule : AbpModule
    {                  
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            MyProjectDtoExtensions.Configure();
        }
    }
}
