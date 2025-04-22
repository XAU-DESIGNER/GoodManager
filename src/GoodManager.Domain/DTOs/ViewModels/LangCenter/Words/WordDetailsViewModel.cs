using GoodManager.Domain.Common;
using GoodManager.Domain.Enums.LangCenter;
using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.DTOs.ViewModels.LangCenter.Words;

public class WordDetailsViewModel
{
    public int Id { get; set; }

    [Display(Name = "عنوان")]
    public string? Title { get; set; }

    [Display(Name = "معنی")]
    public string? Meaning { get; set; }

    [Display(Name = "نوع کلمه")]
    public WordType WordType { get; set; }
}