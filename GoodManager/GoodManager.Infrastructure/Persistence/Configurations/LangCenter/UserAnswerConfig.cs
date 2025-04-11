using GoodManager.Domain.Models.LangCenter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodManager.Infrastructure.Persistence.Configurations.LangCenter;

public class UserAnswerConfig : IEntityTypeConfiguration<UserAnswer>
{
    public void Configure(EntityTypeBuilder<UserAnswer> builder)
    {
        builder.HasKey(x => x.Id);

        #region Properties

        builder.Property(x => x.Score)
            .IsRequired();

        builder.Property(x => x.Answer)
            .HasMaxLength(300);

        #endregion

        #region Relations

        builder.HasOne(x => x.Result)
            .WithMany(x => x.Answers)
            .HasForeignKey(x => x.ResultId)
            .IsRequired();

        builder.HasOne(x => x.Question)
            .WithMany(x => x.Answers)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(x => x.QuestionId)
            .IsRequired();

        #endregion
    }
}