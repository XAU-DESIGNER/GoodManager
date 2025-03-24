namespace GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions;

public class AccountingTransactionDetailsForFilterViewModel
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public bool IsDelete { get; set; }
}