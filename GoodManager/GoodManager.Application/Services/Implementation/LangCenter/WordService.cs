using GoodManager.Application.Security;
using GoodManager.Application.Services.Interfaces.LangCenter;
using GoodManager.Domain.Common;
using GoodManager.Domain.Common.Filter;
using GoodManager.Domain.DTOs.ViewModels.LangCenter.Words;
using GoodManager.Domain.Enums.Common;
using GoodManager.Domain.Interfaces.LangCenter;
using GoodManager.Domain.Models.LangCenter;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace GoodManager.Application.Services.Implementation.LangCenter;

public class WordService(IWordRepository wordRepository) : IWordService
{
    public async Task<FilterWordsViewModel> FilterAsync(FilterWordsViewModel filter)
    {
        filter ??= new();

        var conditions = Filter.GenerateConditions<Word>();

        #region Filter

        if (!string.IsNullOrEmpty(filter.Title))
        {
            conditions.Add(x => EF.Functions.Like(x.Title, $"%{filter.Title}%"));
        }

        switch (filter.IsDeleteStatus)
        {
            case DeleteStatus.All:
                conditions.Add(x => x.IsDeleted || !x.IsDeleted);
                break;
            case DeleteStatus.Deleted:
                conditions.Add(x => x.IsDeleted);
                break;
            case DeleteStatus.NotDeleted:
                conditions.Add(x => !x.IsDeleted);
                break;
        }

        #endregion

        await wordRepository.FilterAsync(filter, conditions,
            x => x.Adapt<WordDetailsForFilterViewModel>(), orderByDesc: x => x.CreatedDateOnUtc);

        return filter;
    }

    public async Task<Result> CreateAsync(CreateWordViewModel model)
    {
        #region Validations

        model.Title = model.Title?.SanitizeTextAndTrim();
        model.Meaning = model.Meaning?.SanitizeTextAndTrim();

        bool isExist = await wordRepository.AnyAsync(x => x.Title == model.Title);
        if (isExist) return Result.Failure(ErrorMessages.AlreadyExistError);

        #endregion

        #region Map and insert to database

        var modelToInsert = model.Adapt<Word>();

        await wordRepository.InsertAsync(modelToInsert);
        await wordRepository.SaveChangesAsync();

        #endregion

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var word = await wordRepository.FirstOrDefaultAsync(x => x.Id == id);
        if (word == null) return Result.Failure(ErrorMessages.NotFoundError);

        wordRepository.SoftDelete(word);
        await wordRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> UpdateAsync(UpdateWordViewModel model)
    {
        var objectFromDataBase = await wordRepository.GetByIdAsync(model.Id);
        
        #region Validations

        if (objectFromDataBase == null) return Result.Failure(ErrorMessages.OperationFailedError);
        
        model.Title = model.Title?.SanitizeTextAndTrim();
        model.Meaning = model.Meaning?.SanitizeTextAndTrim();

        bool isExist = false;

        if (objectFromDataBase.Title != model.Title)
            isExist = await wordRepository.AnyAsync(x => x.Title == model.Title);

        if (isExist) return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "عنوان"));

        #endregion

        model.Adapt(objectFromDataBase);

        wordRepository.Update(objectFromDataBase);
        await wordRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result<UpdateWordViewModel>> GetByIdForUpdateAsync(int id)
    {
        var word = await wordRepository.GetByIdAsync(id);
        if (word == null) return Result.Failure<UpdateWordViewModel>(ErrorMessages.NotFoundError);

        return word.Adapt<UpdateWordViewModel>();
    }

    public async Task<Result<WordDetailsViewModel>> GetByIdAsync(int id)
    {
        var word = await wordRepository.GetByIdAsync(id);
        if (word == null) return Result.Failure<WordDetailsViewModel>(ErrorMessages.NotFoundError);

        return word.Adapt<WordDetailsViewModel>();
    }
}