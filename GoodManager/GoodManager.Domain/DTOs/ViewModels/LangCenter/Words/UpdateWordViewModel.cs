using GoodManager.Domain.Common;
using GoodManager.Domain.Enums.LangCenter;
using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.DTOs.ViewModels.LangCenter.Words;

public class UpdateWordViewModel
{
    public int Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(191, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? Title { get; set; }

    [Display(Name = "معنی")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(191, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? Meaning { get; set; }

    [Display(Name = "نوع کلمه")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    public WordType WordType { get; set; }
}