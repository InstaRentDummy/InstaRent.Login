using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace InstaRent.Login;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LoginHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class LoginConsoleApiClientModule : AbpModule
{

}
