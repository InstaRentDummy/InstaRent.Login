using InstaRent.Login.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace InstaRent.Login.Permissions;

public class LoginPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LoginPermissions.GroupName, L("Permission:Login"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LoginResource>(name);
    }
}
