using GoodManager.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.Models.LangCenter;

public class UserAnswer:AuditBaseEntity
{
    #region Properties

    public int ResultId { get; set; }
    public int QuestionId { get; set; }

    [Range(0,100)]
    public int Score { get; set; }

    public string? Answer { get; set; }

    public bool IsCorrect { get; set; }
    public bool IsSkipped { get; set; } = false;

    #endregion

    #region Relations

    public QuizResult? Result { get; set; }
    public QuizQuestion? Question { get; set; }

    #endregion
}