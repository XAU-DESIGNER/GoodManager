using GoodManager.Domain.Enums.Accounting;
using GoodManager.Domain.Enums.Common;

namespace GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions;

public class CreateAccountingTransactionViewModel
{
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public AccountingTransactionType TransactionType { get; set; }
    public AccountingTransactionCause TransactionCause { get; set; }
    public AccountingTransactionWay TransactionWay { get; set; }

    public CurrencyType CurrencyType { get; set; }
}