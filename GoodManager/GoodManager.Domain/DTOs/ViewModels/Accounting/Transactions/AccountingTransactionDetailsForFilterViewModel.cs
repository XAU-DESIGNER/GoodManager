using GoodManager.Domain.Enums.Accounting;

namespace GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions;

public class AccountingTransactionDetailsForFilterViewModel
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public AccountingTransactionType TransactionType{ get; set; }
    public AccountingTransactionCause TransactionCause { get; set; }
    public AccountingTransactionWay TransactionWay { get; set; }
    public bool IsDelete { get; set; }
}