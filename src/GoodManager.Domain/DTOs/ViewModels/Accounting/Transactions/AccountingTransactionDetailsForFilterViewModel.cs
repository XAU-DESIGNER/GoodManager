using GoodManager.Domain.Enums.Accounting;
using GoodManager.Domain.Enums.Common;

namespace GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions;

public class AccountingTransactionDetailsForFilterViewModel
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedDateOnUtc { get; set; }
    public AccountingTransactionType TransactionType { get; set; }
    public AccountingTransactionCause TransactionCause { get; set; }
    public AccountingTransactionWay TransactionWay { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public bool IsDelete { get; set; }
}