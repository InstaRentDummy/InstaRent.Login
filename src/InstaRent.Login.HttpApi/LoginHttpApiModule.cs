using Localization.Resources.AbpUi;
using InstaRent.Login.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace InstaRent.Login;

[DependsOn(
    typeof(LoginApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class LoginHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(LoginHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<LoginResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
