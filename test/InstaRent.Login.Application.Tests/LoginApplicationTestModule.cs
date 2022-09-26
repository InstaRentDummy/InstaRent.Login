using Volo.Abp.Modularity;

namespace InstaRent.Login;

[DependsOn(
    typeof(LoginApplicationModule),
    typeof(LoginDomainTestModule)
    )]
public class LoginApplicationTestModule : AbpModule
{

}
