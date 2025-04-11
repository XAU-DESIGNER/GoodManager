using GoodManager.Domain.Enums.LangCenter;
using GoodManager.Domain.Models.Common;

namespace GoodManager.Domain.Models.LangCenter;

public class Quiz : AuditBaseEntity
{
    #region Properties

    public string? Title { get; set; }
    public int QuestionsCount { get; set; }

    public QuizType QuizType { get; set; }

    public TimeSpan? TimeLimit { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public bool IsPrivate { get; set; }

    #endregion

    #region Relations

    public ICollection<QuizQuestion>? Questions { get; set; }
    public ICollection<QuizResult>? Results { get; set; }

    #endregion
}