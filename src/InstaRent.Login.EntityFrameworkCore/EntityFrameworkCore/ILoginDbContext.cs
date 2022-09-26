using InstaRent.Login.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace InstaRent.Login.EntityFrameworkCore;

[ConnectionStringName(LoginDbProperties.ConnectionStringName)]
public interface ILoginDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */

    DbSet<User> Users { get; set; }
}
