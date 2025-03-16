using GoodManager.Domain.Models.Common;
using GoodManager.Domain.Models.Users;

namespace GoodManager.Domain.Models.Accounting;

public class Income : AuditBaseEntity
{
    #region Properties

    public int Amount { get; set; } = 0;
    public int AccountingWalletId { get; set; }

    #endregion

    #region Relations

    public AccountingWallet? AccountingWallet { get; set; }

    #endregion
}