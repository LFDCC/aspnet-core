using Volo.Abp.AuditLogging;
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

        }
    }
}
