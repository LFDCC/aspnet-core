using Localization.Resources.AbpUi;

using MyProject.Localization;

using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace MyProject
{
    [DependsOn(
        typeof(MyProjectApplicationContractsModule)
        )]
    public class MyProjectHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<MyProjectResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
