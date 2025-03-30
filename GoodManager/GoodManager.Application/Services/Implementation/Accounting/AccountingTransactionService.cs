using GoodManager.Application.Services.Interfaces.Accounting;
using GoodManager.Domain.Common;
using GoodManager.Domain.Common.Filter;
using GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions;
using GoodManager.Domain.DTOs.ViewModels.LangCenter.Words;
using GoodManager.Domain.Enums.Accounting;
using GoodManager.Domain.Enums.Common;
using GoodManager.Domain.Interfaces.Accounting;
using GoodManager.Domain.Models.Accounting;
using Mapster;

namespace GoodManager.Application.Services.Implementation.Accounting;

public class AccountingTransactionService(IAccountingTransactionRepository accountingTransactionRepository) : IAccountingTransactionService
{
    public async Task<FilterAccountingTransactionViewModel> FilterAsync(FilterAccountingTransactionViewModel filter)
    {
        filter ??= new();

        var filterConditions = Filter.GenerateConditions<AccountingTransaction>();

        #region Filter

        switch (filter.DeleteStatus)
        {
            case DeleteStatus.All:
                filterConditions.Add(x => x.IsDeleted || !x.IsDeleted);
                break;
            case DeleteStatus.Deleted:
                filterConditions.Add(x => x.IsDeleted);
                break;
            case DeleteStatus.NotDeleted:
                filterConditions.Add(x => !x.IsDeleted);
                break;
        }

        if (filter.UserId != null)
        {
            filterConditions.Add(x => x.UserId == filter.UserId);
        }

        #endregion

        await accountingTransactionRepository.FilterAsync(filter, filterConditions,
            mapping: x => x.Adapt<AccountingTransactionDetailsForFilterViewModel>(),
            orderByDesc: x => x.CreatedDateOnUtc);

        return filter;
    }

    public async Task<Result> CreateAsync(CreateAccountingTransactionViewModel model)
    {
        #region Validations



        #endregion

        var objectToInsert = model.Adapt<AccountingTransaction>();

        #region Update balance

        var userLatestTransaction = await accountingTransactionRepository.
            FirstOrDefaultAsync(x => x.UserId == model.UserId && !x.IsDeleted, orderByDesc: x => x.Id);

        if (userLatestTransaction == null)
        {
            if (model.TransactionType == AccountingTransactionType.Cost) return Result.Failure(ErrorMessages.NotEnoughBalance);

            objectToInsert.Balance = model.Amount;
        }
        else
        {
            if (userLatestTransaction.Balance < model.Amount && model.TransactionType == AccountingTransactionType.Cost) return Result.Failure(ErrorMessages.NotEnoughBalance);

            var balance = userLatestTransaction.Balance;

            if (model.TransactionType == AccountingTransactionType.Income)
            {
                objectToInsert.Balance = balance + model.Amount;
            }
            else
            {
                objectToInsert.Balance = balance - model.Amount;
            }
        }

        #endregion

        await accountingTransactionRepository.InsertAsync(objectToInsert);
        await accountingTransactionRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var maximumTransactionId = accountingTransactionRepository.GetLatestTransactionId();
        if (id != maximumTransactionId) return Result.Failure(ErrorMessages.IsNotLatestTransaction);

        var transaction = await accountingTransactionRepository.FirstOrDefaultAsync(x => x.Id == id);
        if (transaction == null) return Result.Failure(ErrorMessages.NotFoundError);

        accountingTransactionRepository.SoftDelete(transaction);
        await accountingTransactionRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result<TransactionChartOverviewViewModel>> GetOverViewForChartAsync(int userId)
    {
        var latestTransaction = await accountingTransactionRepository.FirstOrDefaultAsync(x => x.UserId == userId && !x.IsDeleted,
            orderByDesc: x => x.Id);

        var result = new TransactionChartOverviewViewModel()
        {
            Balance = latestTransaction?.Balance ?? 0
        };

        return Result.Success(value: result);
    }

    public async Task<Result<UpdateAccountingTransactionViewModel>> GetByIdForUpdateAsync(int id)
    {
        var transaction = await accountingTransactionRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (transaction == null) return Result.Failure<UpdateAccountingTransactionViewModel>(ErrorMessages.NotFoundError);

        return transaction.Adapt<UpdateAccountingTransactionViewModel>();
    }

    public async Task<Result> UpdateAsync(UpdateAccountingTransactionViewModel model)
    {
        var objectFromDataBase = await accountingTransactionRepository.GetByIdAsync(model.Id);

        #region Validations

        if (objectFromDataBase == null) return Result.Failure(ErrorMessages.OperationFailedError);

        #endregion

        model.Adapt(objectFromDataBase);

        accountingTransactionRepository.Update(objectFromDataBase);
        await accountingTransactionRepository.SaveChangesAsync();

        return Result.Success();
    }
}