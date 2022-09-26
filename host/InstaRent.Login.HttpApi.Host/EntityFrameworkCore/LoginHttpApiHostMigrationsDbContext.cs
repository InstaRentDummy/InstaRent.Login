using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace InstaRent.Login.EntityFrameworkCore;

public class LoginHttpApiHostMigrationsDbContext : AbpDbContext<LoginHttpApiHostMigrationsDbContext>
{
    public LoginHttpApiHostMigrationsDbContext(DbContextOptions<LoginHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureLogin();
    }
}
