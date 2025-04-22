using GoodManager.Domain.Enums.LangCenter;
using GoodManager.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.Models.LangCenter;

public class QuizQuestion : AuditBaseEntity
{
    #region Properties

    public int QuizId { get; set; }

    [Range(0,100)]
    public int Mark { get; set; } = 1;
    public string? Title { get; set; }
    public string? CorrectAnswer { get; set; }

    public List<string>? Options { get; set; }
    public QuestionType QuestionType { get; set; } = QuestionType.Dictation;
    public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Medium;

    #endregion

    #region Relations

    public Quiz? Quiz { get; set; }
    public ICollection<UserAnswer>? Answers { get; set; }

    #endregion
}