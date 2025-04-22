using GoodManager.Domain.Models.LangCenter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodManager.Infrastructure.Persistence.Configurations.LangCenter;

public class QuizResultConfig : IEntityTypeConfiguration<QuizResult>
{
    public void Configure(EntityTypeBuilder<QuizResult> builder)
    {
        builder.HasKey(x => x.Id);

        #region Properties

        builder.Property(x => x.CorrectAnswers)
            .IsRequired();

        builder.Property(x => x.WrongAnswers)
            .IsRequired();

        builder.Property(x => x.SkippedQuestions)
            .IsRequired();

        builder.Property(x => x.Duration)
            .IsRequired();

        builder.Property(x => x.CompletedAt)
            .IsRequired();

        builder.Property(x => x.Score)
            .IsRequired();

        #endregion

        #region Relations

        builder.HasOne(x => x.Quiz)
            .WithMany(x => x.Results)
            .HasForeignKey(x => x.QuizId)
            .IsRequired();
        
        builder.HasOne(x => x.User)
            .WithMany(x => x.Results)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasMany(x => x.Answers)
            .WithOne(x => x.Result)
            .HasForeignKey(x => x.ResultId)
            .IsRequired();

        #endregion
    }
}