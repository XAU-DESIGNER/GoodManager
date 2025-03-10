using GoodManager.Domain.Common;
using GoodManager.Domain.DTOs.ViewModels.LangCenter.Words;

namespace GoodManager.Application.Services.Interfaces.LangCenter;

public interface IWordService
{
    Task<FilterWordsViewModel> FilterAsync(FilterWordsViewModel filter);
    
    Task<Result> CreateAsync(CreateWordViewModel model);

    Task<Result> UpdateAsync(UpdateWordViewModel model);

    Task<Result<WordDetailsViewModel>> GetByIdAsync(int id);

    Task<Result<UpdateWordViewModel>> GetByIdForUpdateAsync(int id);

    Task<Result> DeleteAsync(int id);
}