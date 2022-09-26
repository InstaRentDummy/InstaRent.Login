using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace InstaRent.Login;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(LoginDomainSharedModule)
)]
public class LoginDomainModule : AbpModule
{

}
