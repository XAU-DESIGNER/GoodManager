using GoodManager.Domain.Models.LangCenter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodManager.Infrastructure.Persistence.Configurations.LangCenter;

public class WordConfig : IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
    {
        builder.HasKey(x => x.Id);

        #region Properties

        builder.Property(x => x.Title)
            .HasMaxLength(192)
            .IsRequired();

        builder.Property(x => x.Meaning)
            .HasMaxLength(192)
            .IsRequired();

        builder.Property(x => x.Descriptions)
            .HasMaxLength(500);

        #endregion

        #region Relations

        builder.HasOne(x => x.User)
            .WithMany(x => x.Words)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
    }
}