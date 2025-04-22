using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.Enums.Common;

public enum CurrencyType
{
    [Display(Name = "تـومان")] Toman,
    [Display(Name = "دلار")] Dollar
}