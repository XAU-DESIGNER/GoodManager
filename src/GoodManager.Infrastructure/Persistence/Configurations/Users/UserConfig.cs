using GoodManager.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodManager.Infrastructure.Persistence.Configurations.Users;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        #region Proprties

        builder.Property(x => x.FullName).HasMaxLength(191);
        builder.Property(x => x.UserName).HasMaxLength(30);
        builder.Property(x => x.Email).HasMaxLength(50);
        builder.Property(x => x.Password).HasMaxLength(50);
        builder.Property(x => x.AvatarName).HasMaxLength(50);

        #endregion

        #region Relations

        builder.HasMany(x => x.AccountingTransactions)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired(true);

        builder.HasMany(x => x.Words)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired();

        builder.HasMany(x => x.Quizzes)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired();

        builder.HasMany(x => x.Results)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        #endregion
    }
}