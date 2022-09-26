using InstaRent.Login.Localization;
using Volo.Abp.Application.Services;

namespace InstaRent.Login;

public abstract class LoginAppService : ApplicationService
{
    protected LoginAppService()
    {
        LocalizationResource = typeof(LoginResource);
        ObjectMapperContext = typeof(LoginApplicationModule);
    }
}
