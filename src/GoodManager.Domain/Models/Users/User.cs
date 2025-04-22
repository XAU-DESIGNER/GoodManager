using GoodManager.Domain.Models.Accounting;
using GoodManager.Domain.Models.Common;
using GoodManager.Domain.Models.LangCenter;

namespace GoodManager.Domain.Models.Users;

public class User : AuditBaseEntity
{
    #region Properties

    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? AvatarName { get; set; }
    public int AccountingWalletId { get; set; }

    #endregion

    #region Relations

    public ICollection<AccountingTransaction>? AccountingTransactions { get; set; }
    public ICollection<Word>? Words { get; set; }
    public ICollection<Quiz>? Quizzes { get; set; }
    public ICollection<QuizResult>? Results { get; set; }

    #endregion
}