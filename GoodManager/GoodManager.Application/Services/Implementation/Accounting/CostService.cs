using GoodManager.Application.Services.Interfaces.Accounting;
using GoodManager.Domain.Common.Filter;
using GoodManager.Domain.DTOs.ViewModels.Accounting.Costs;
using GoodManager.Domain.Interfaces.Accounting;
using GoodManager.Domain.Models.Accounting;
using Mapster;

namespace GoodManager.Application.Services.Implementation.Accounting;

public class CostService(ICostRepository costRepository) : ICostService
{
    public async Task<FilterCostsViewModel> FilterAsync(FilterCostsViewModel filter)
    {
        filter ??= new FilterCostsViewModel();

        var filterConditions = Filter.GenerateConditions<Cost>();

        #region Filter

        #endregion

        await costRepository.FilterAsync(filter, filterConditions,
            x => x.Adapt<CostDetailsForFilterViewModel>(),orderByDesc:x=>x.CreatedDateOnUtc);

        return filter;
    }
}