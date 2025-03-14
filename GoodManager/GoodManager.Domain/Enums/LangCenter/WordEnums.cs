using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.Enums.LangCenter;

public enum WordType
{
    [Display(Name = "نامشخص")] NoData,
    [Display(Name = "اسم")] Noun,
    [Display(Name = "صفت")] Adjective,
    [Display(Name = "فعل")] Verb,
    [Display(Name = "اسم و صفت")] NounAdjective,
    [Display(Name = "اسم، صفت، قید و حرف اضافه")] NounAdjectiveAdverbPreposition,
    [Display(Name = "اسم، صفت و قید")] NounAdjectiveAdverb
}