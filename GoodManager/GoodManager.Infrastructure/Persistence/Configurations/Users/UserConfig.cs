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

        builder.Property(user => user.FullName).HasMaxLength(191);
        builder.Property(user => user.UserName).HasMaxLength(30);
        builder.Property(user => user.Email).HasMaxLength(50);
        builder.Property(user => user.Password).HasMaxLength(50);
        builder.Property(user => user.AvatarName).HasMaxLength(50);

        #endregion
    }
}