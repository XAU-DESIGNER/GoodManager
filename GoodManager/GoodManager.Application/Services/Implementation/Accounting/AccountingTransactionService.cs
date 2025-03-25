using GoodManager.Application.Services.Interfaces.Accounting;
using GoodManager.Domain.Common;
using GoodManager.Domain.Common.Filter;
using GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions;
using GoodManager.Domain.Enums.Common;
using GoodManager.Domain.Interfaces.Accounting;
using GoodManager.Domain.Models.Accounting;
using Mapster;

namespace GoodManager.Application.Services.Implementation.Accounting;

public class AccountingTransactionService(IAccountingTransactionRepository accountingTransactionRepository) : IAccountingTransactionService
{
    public async Task<FilterAccountingTransactionViewModel> FilterAsync(FilterAccountingTransactionViewModel filter)
    {
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

        #region Convert amount to dollar

        //if(model.CurrencyType == CurrencyType.Toman)
        //{
            
        //}

        #endregion

        var objectToInsert = model.Adapt<AccountingTransaction>();

        await accountingTransactionRepository.InsertAsync(objectToInsert);
        await accountingTransactionRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var transaction = await accountingTransactionRepository.FirstOrDefaultAsync(x => x.Id == id);
        if (transaction == null) return Result.Failure(ErrorMessages.NotFoundError);

        accountingTransactionRepository.SoftDelete(transaction);
        await accountingTransactionRepository.SaveChangesAsync();

        return Result.Success();
    }
}