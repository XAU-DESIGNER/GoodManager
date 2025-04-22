using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.Enums.LangCenter;

public enum QuestionType
{
    [Display(Name = "دیکته")]Dictation,
    [Display(Name = "چند گزینه ای")] MultipleChoice,
    [Display(Name = "وصل کردنی")]Matching,
    [Display(Name = "صحیح یا غلط")]TrueFalse,
    [Display(Name = "جای خالی")]FillInTheBlank
}