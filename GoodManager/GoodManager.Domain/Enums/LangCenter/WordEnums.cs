using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.Enums.LangCenter;

public enum WordType
{
    [Display(Name = "نامشخص")] NoData,
    [Display(Name = "اسم")] Noun,
    [Display(Name = "صفت")] Adjective,
    [Display(Name = "فعل")] Verb
}