using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace MyProject
{
    [DependsOn(
        typeof(MyProjectDomainModule),
        typeof(AbpAutoMapperModule),
        typeof(MyProjectApplicationContractsModule)
        )]
    public class MyProjectApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MyProjectApplicationModule>();
            });
        }
    }
}
