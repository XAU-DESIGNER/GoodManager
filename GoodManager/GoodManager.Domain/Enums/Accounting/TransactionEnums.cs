using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.Enums.Accounting;

public enum AccountingTransactionCause
{
    [Display(Name = "امور آموزشی")] Learn,
    [Display(Name = "حمل و نقل")] Transportation,
    [Display(Name = "لوازم کامپیوتری")] Accessories,
    [Display(Name = "امـور ورزشی")] Sport,
    [Display(Name = "آرایشگاه و پاکیزگی")] HairdressingAndHygiene,
    [Display(Name = "سلامـتی")] Health,
    [Display(Name = "غـیره")] Others
}

public enum AccountingTransactionWay
{
    [Display(Name = "ارزهای دیجیتال")] Cryptocurrency,
    [Display(Name = "بانک")] Bank,
    [Display(Name = "نقدی")] Cash
}

public enum AccountingTransactionType
{
    [Display(Name = "درآمـد")] Income,
    [Display(Name = "هـزینه")] Cost
}