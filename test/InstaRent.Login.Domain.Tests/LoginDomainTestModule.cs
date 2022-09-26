using InstaRent.Login.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace InstaRent.Login;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(LoginEntityFrameworkCoreTestModule)
    )]
public class LoginDomainTestModule : AbpModule
{

}
