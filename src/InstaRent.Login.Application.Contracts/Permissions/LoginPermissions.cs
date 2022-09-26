using Volo.Abp.Reflection;

namespace InstaRent.Login.Permissions;

public class LoginPermissions
{
    public const string GroupName = "Login";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(LoginPermissions));
    }
}
