using GoodManager.Domain.Enums.LangCenter;
using GoodManager.Domain.Models.Common;

namespace GoodManager.Domain.Models.LangCenter;

public class QuizQuestion : AuditBaseEntity
{
    #region Properties

    public int QuizId { get; set; }
    public int Mark { get; set; } = 1;
    public string? Text { get; set; }
    public string? CorrectAnswer { get; set; }

    //[Range(1, 10)]
    public List<string> Options { get; set; } = new List<string>();
    public QuestionType QuestionType { get; set; } = QuestionType.Dictation;
    public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Medium;

    #endregion

    #region Relations

    public Quiz? Quiz { get; set; }
    public ICollection<UserAnswer>? Answers { get; set; }

    #endregion
}