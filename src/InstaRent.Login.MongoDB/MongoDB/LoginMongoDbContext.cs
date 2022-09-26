using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace InstaRent.Login.MongoDB;

[ConnectionStringName(LoginDbProperties.ConnectionStringName)]
public class LoginMongoDbContext : AbpMongoDbContext, ILoginMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureLogin();
    }
}
