using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace InstaRent.Login.MongoDB;

[ConnectionStringName(LoginDbProperties.ConnectionStringName)]
public interface ILoginMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
