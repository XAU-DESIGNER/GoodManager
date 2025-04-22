using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.Enums.LangCenter;

public enum DifficultyLevel
{
    [Display(Name = "آسـان")] Easy,
    [Display(Name = "متوسـط")] Medium,
    [Display(Name = "سـخت")] Hard,
    [Display(Name = "دشـوار")] Expert
}