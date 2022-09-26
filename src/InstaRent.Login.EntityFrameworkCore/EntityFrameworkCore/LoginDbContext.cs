using InstaRent.Login.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace InstaRent.Login.EntityFrameworkCore;

[ConnectionStringName(LoginDbProperties.ConnectionStringName)]
public class LoginDbContext : AbpDbContext<LoginDbContext>, ILoginDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public DbSet<User> Users { get; set; }

    public LoginDbContext(DbContextOptions<LoginDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureLogin();

    }
}
