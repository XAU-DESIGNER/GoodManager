using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.Enums.Accounting;

public enum AccountingTransactionCause
{
    [Display(Name = "نامشخـص")] Others,
    [Display(Name = "امور آموزشی")] Learn,
    [Display(Name = "حمل و نقل")] Transportation,
    [Display(Name = "لوازم کامپیوتری")] Accessories,
    [Display(Name = "امـور ورزشی")] Sport,
    [Display(Name = "آرایشگاه و پاکیزگی")] HairdressingAndHygiene,
    [Display(Name = "سلامـتی")] Health,
    [Display(Name = "کریپـتو")] Crypto,
    [Display(Name = "فارکـس")] Forex,
    [Display(Name = "کارمندی")] Employment,
    [Display(Name = "امـور خانـوادگی")]Family,
    [Display(Name = "غذای ناسالم")]JunkFood,
    [Display(Name = "خرید بسته اینترنت")] BuyInternetService
}

public enum AccountingTransactionWay
{
    [Display(Name = "بانک")] Bank,
    [Display(Name = "نقدی")] Cash,
    [Display(Name = "ارزهای دیجیتال")] Cryptocurrency
}

public enum AccountingTransactionType
{
    [Display(Name = "درآمـد")] Income,
    [Display(Name = "هـزینه")] Cost
}