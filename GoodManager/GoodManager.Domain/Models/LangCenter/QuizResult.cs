using GoodManager.Domain.Models.Common;
using GoodManager.Domain.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.Models.LangCenter;

public class QuizResult : AuditBaseEntity
{
    #region Properties

    public int UserId { get; set; }
    public int QuizId { get; set; }

    public int CorrectAnswers { get; set; }
    public int WrongAnswers { get; set; }
    public int SkippedQuestions { get; set; }

    [Range(0, 100)]
    public int Score { get; set; }

    public TimeSpan Duration { get; set; }
    public DateTime CompletedAt { get; set; } = DateTime.UtcNow;


    #endregion

    #region Relations

    public User? User { get; set; }
    public Quiz? Quiz { get; set; }
    public ICollection<UserAnswer>? Answers { get; set; }

    #endregion
}