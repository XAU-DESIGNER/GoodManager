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
}