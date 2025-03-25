using GoodManager.Domain.Attributes;
using GoodManager.Domain.Common.Filter;
using GoodManager.Domain.Enums.Common;
using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions;

public class FilterAccountingTransactionViewModel : BasePaging<AccountingTransactionDetailsForFilterViewModel>
{
    [Display(Name = "وضعیت حذف"), FilterInput]
    public DeleteStatus DeleteStatus { get; set; }
}