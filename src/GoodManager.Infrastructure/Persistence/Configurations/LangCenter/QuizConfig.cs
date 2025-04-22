using GoodManager.Domain.Models.LangCenter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodManager.Infrastructure.Persistence.Configurations.LangCenter;

public class QuizConfig : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasKey(x => x.Id);

        #region Properties

        builder.Property(x => x.Title)
            .HasMaxLength(192)
            .IsRequired();

        #endregion

        #region Relations

        builder.HasOne(x => x.User)
            .WithMany(x => x.Quizzes)
            .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.Questions)
            .WithOne(x => x.Quiz)
            .HasForeignKey(x => x.QuizId);

        builder.HasMany(x => x.Results)
            .WithOne(x => x.Quiz)
            .HasForeignKey(x => x.QuizId);

        #endregion
    }
}