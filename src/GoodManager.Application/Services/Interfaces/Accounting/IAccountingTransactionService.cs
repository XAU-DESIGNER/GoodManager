using GoodManager.Domain.Common;
using GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions;

namespace GoodManager.Application.Services.Interfaces.Accounting;

public interface IAccountingTransactionService
{
    Task<FilterAccountingTransactionViewModel> FilterAsync(FilterAccountingTransactionViewModel filter);
    Task<Result> CreateAsync(CreateAccountingTransactionViewModel model);
    Task<Result> UpdateAsync(UpdateAccountingTransactionViewModel model);
    Task<Result<UpdateAccountingTransactionViewModel>> GetByIdForUpdateAsync(int id);
    Task<Result> DeleteAsync(int id);
}