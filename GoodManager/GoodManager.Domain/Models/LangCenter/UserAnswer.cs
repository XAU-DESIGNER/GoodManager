using GoodManager.Domain.Models.Common;

namespace GoodManager.Domain.Models.LangCenter;

public class UserAnswer:AuditBaseEntity
{
    #region Properties

    public int QuizResultId { get; set; }
    public int QuestionId { get; set; }
    public double Score { get; set; }

    public string? Answer { get; set; }

    public DateTime AnsweredAt { get; set; } = DateTime.UtcNow;
    public bool IsCorrect { get; set; }
    public bool IsSkipped { get; set; } = false;

    #endregion

    #region Relations

    public QuizResult? QuizResult { get; set; }
    public QuizQuestion? QuizQuestion { get; set; }

    #endregion
}