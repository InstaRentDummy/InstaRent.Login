using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace InstaRent.Login;

[DependsOn(
    typeof(LoginApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class LoginHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(LoginApplicationContractsModule).Assembly,
            LoginRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<LoginHttpApiClientModule>();
        });

    }
}
