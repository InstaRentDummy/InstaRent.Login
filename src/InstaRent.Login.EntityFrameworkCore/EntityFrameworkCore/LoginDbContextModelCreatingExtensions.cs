using InstaRent.Login.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace InstaRent.Login.EntityFrameworkCore;

public static class LoginDbContextModelCreatingExtensions
{
    public static void ConfigureLogin(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(LoginDbProperties.DbTablePrefix + "Questions", LoginDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */

        builder.Entity<User>(b =>
        {
            b.ToTable(LoginDbProperties.DbTablePrefix + "Users",
                LoginDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            b.Property(x => x.Email).IsRequired().HasMaxLength(64);
            b.Property(x => x.Password).IsRequired().HasMaxLength(64);
        });
    }
}
