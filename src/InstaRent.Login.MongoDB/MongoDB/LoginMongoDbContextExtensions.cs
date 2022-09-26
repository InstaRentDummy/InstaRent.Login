using Volo.Abp;
using Volo.Abp.MongoDB;

namespace InstaRent.Login.MongoDB;

public static class LoginMongoDbContextExtensions
{
    public static void ConfigureLogin(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
