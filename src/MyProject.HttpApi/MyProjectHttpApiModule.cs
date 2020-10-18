using Localization.Resources.AbpUi;

using MyProject.Localization;

using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;

namespace MyProject
{
    [DependsOn(
        typeof(MyProjectApplicationContractsModule)   ,
          typeof(AbpPermissionManagementHttpApiModule)
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
