using GoodManager.Domain.Attributes;
using GoodManager.Domain.Common;
using GoodManager.Domain.Common.Filter;
using GoodManager.Domain.Enums.Common;
using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.DTOs.ViewModels.LangCenter.Words;

public class FilterWordsViewModel : BasePaging<WordDetailsForFilterViewModel>
{
    [Display(Name = "عنوان"), FilterInput]
    [MaxLength(191, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? Title { get; set; }

    [Display(Name = "وضعیت حذف"), FilterInput]
    public DeleteStatus IsDeleteStatus { get; set; }
}