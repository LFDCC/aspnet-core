using Volo.Abp.Modularity;

namespace MyProject
{
    [DependsOn(
        typeof(MyProjectDomainSharedModule)
    )]
    public class MyProjectDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
