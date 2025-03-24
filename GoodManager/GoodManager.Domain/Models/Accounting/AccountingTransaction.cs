using GoodManager.Domain.Enums.Accounting;
using GoodManager.Domain.Models.Common;
using GoodManager.Domain.Models.Users;

namespace GoodManager.Domain.Models.Accounting;

public class AccountingTransaction : AuditBaseEntity
{
    #region Properties

    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
    public AccountingTransactionType TransactionType { get; set; }
    public AccountingTransactionCause TransactionCause { get; set; }
    public AccountingTransactionWay TransactionWay { get; set; }

    #endregion

    #region Relations

    public User? User { get; set; }

    #endregion
}