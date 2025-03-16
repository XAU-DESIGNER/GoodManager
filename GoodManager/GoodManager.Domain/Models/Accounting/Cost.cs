using GoodManager.Domain.Enums.Accounting;
using GoodManager.Domain.Models.Common;
using GoodManager.Domain.Models.Users;

namespace GoodManager.Domain.Models.Accounting;

public class Cost : AuditBaseEntity
{
    #region Properties

    public int Amount { get; set; }
    public CostTypes Type { get; set; }
    public CostPriority Priority { get; set; }
    public int AccountingWalletId { get; set; }

    #endregion

    #region Relations

    public AccountingWallet? AccountingWallet { get; set; }

    #endregion
}