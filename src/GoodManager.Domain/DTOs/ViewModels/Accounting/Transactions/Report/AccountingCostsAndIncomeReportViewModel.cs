namespace GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions.Report;

public class AccountingCostsAndIncomeReportViewModel
{
    public decimal CostsSum => Costs.Sum();
    public decimal IncomeSum => Income.Sum();

    public List<decimal> Costs { get; set; } = [];
    public List<decimal> Income { get; set; } = [];
}