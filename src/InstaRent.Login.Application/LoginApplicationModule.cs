using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace InstaRent.Login;

[DependsOn(
    typeof(LoginDomainModule),
    typeof(LoginApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class LoginApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<LoginApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<LoginApplicationModule>(validate: true);
        });
    }
}
