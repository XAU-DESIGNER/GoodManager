using GoodManager.Application.Convertors;
using GoodManager.Application.Services.Interfaces.Accounting;
using GoodManager.Domain.Common;
using GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions.Report;
using GoodManager.Domain.Enums.Accounting;
using GoodManager.Domain.Interfaces.Accounting;
using System.Globalization;

namespace GoodManager.Application.Services.Implementation.Accounting;

public class AccountingTransactionReportService(IAccountingTransactionRepository accountingTransactionRepository) : IAccountingTransactionReportService
{
    public async Task<Result<AccountingCostsAndIncomeReportViewModel>> GetLastYearCostsAndIncomeAsync(int userId)
    {
        var nowDate = DateTime.UtcNow;
        var lastYearStart = new DateTime(nowDate.Year, 1, 1);
        var lastYearEnd = new DateTime(nowDate.Year + 1, 1, 1).AddDays(-1);

        var transactions = await accountingTransactionRepository
            .GetAllAsync(x => x.CreatedDateOnUtc >= lastYearStart && x.CreatedDateOnUtc <= lastYearEnd &&
            x.UserId == userId && !x.IsDeleted);

        var persianCalendar = new PersianCalendar();
        var result = new AccountingCostsAndIncomeReportViewModel();

        for (int month = 1; month <= 12; month++)
        {
            var monthTransactions = transactions
                .Where(x => persianCalendar.GetMonth(x.CreatedDateOnUtc) == month)
                .ToList();

            decimal monthCosts = monthTransactions
                .Where(x => x.TransactionType == AccountingTransactionType.Cost)
                .Sum(x => x.Amount);

            decimal monthIncome = monthTransactions
                .Where(x => x.TransactionType == AccountingTransactionType.Income)
                .Sum(x => x.Amount);

            result.Costs.Add(monthCosts);
            result.Income.Add(monthIncome);
        }

        return result;
    }
}