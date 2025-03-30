using GoodManager.Domain.Enums.Accounting;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions;

public class UpdateAccountingTransactionViewModel
{
    public int Id { get; set; }

    [Display(Name = "نـوع")]
    public AccountingTransactionType TransactionType { get; set; }
    
    [Display(Name = "دلـیل")]
    public AccountingTransactionCause TransactionCause { get; set; }
    
    [Display(Name = "طـریق انـجام")]
    public AccountingTransactionWay TransactionWay { get; set; }
}
