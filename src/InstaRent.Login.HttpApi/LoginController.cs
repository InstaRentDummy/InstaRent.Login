using InstaRent.Login.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace InstaRent.Login;

public abstract class LoginController : AbpControllerBase
{
    protected LoginController()
    {
        LocalizationResource = typeof(LoginResource);
    }
}
