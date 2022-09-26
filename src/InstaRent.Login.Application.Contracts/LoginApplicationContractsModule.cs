using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace InstaRent.Login;

[DependsOn(
    typeof(LoginDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class LoginApplicationContractsModule : AbpModule
{

}
