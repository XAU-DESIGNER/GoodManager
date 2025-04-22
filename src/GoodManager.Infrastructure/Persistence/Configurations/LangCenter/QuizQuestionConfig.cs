using GoodManager.Domain.Models.LangCenter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Text.Json;

namespace GoodManager.Infrastructure.Persistence.Configurations.LangCenter;

public class QuizQuestionConfig : IEntityTypeConfiguration<QuizQuestion>
{
    public void Configure(EntityTypeBuilder<QuizQuestion> builder)
    {
        builder.HasKey(x => x.Id);

        #region Properties

        builder.Property(x => x.Title)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.CorrectAnswer)
            .HasMaxLength(300)
        .IsRequired();

        //builder.Property(q => q.Options)
        //    .HasConversion(
        //        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
        //        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null));
        #endregion

        #region Relations

        builder.HasOne(x => x.Quiz)
            .WithMany(x => x.Questions)
            .HasForeignKey(x => x.QuizId)
            .IsRequired();

        builder.HasMany(x => x.Answers)
            .WithOne(x => x.Question)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        #endregion
    }
}