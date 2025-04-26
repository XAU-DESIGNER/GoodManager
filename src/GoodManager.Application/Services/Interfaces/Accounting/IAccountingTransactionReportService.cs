using GoodManager.Domain.Common;
using GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions.Report;

namespace GoodManager.Application.Services.Interfaces.Accounting;

public interface IAccountingTransactionReportService
{
    Task<Result<AccountingCostsAndIncomeReportViewModel>> GetLastYearCostsAndIncomeAsync(int userId);
}