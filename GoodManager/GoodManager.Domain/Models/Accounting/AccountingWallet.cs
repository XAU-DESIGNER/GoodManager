using GoodManager.Domain.Models.Common;
using GoodManager.Domain.Models.Users;

namespace GoodManager.Domain.Models.Accounting;

public class AccountingWallet : AuditBaseEntity
{
    #region Properties

    public int Balance { get; set; } = 0;
    public int UserId { get; set; }

    #endregion

    #region Relations

    public User? User { get; set; }
    public ICollection<Cost>? Costs { get; set; }
    public ICollection<Income>? Incomes { get; set; }

    #endregion
}