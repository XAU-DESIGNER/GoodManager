using GoodManager.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.DTOs.ViewModels.Account;

public class RegisterViewModel
{
    [Display(Name = "ایمیل")]
    [EmailAddress(ErrorMessage = ErrorMessages.RegexIncorrectFormat)]
    [MaxLength(30, ErrorMessage = ErrorMessages.MaxLengthError)]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    public string? Email { get; set; }

    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(30, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? UserName { get; set; }

    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(50, ErrorMessage = ErrorMessages.MaxLengthError)]
    [MinLength(8, ErrorMessage = ErrorMessages.MinRangeError)]
    public string? Password { get; set; }

    [Display(Name = "تکرار رمز عبور")]
    [Compare(nameof(Password), ErrorMessage = ErrorMessages.CompareError)]
    public string? RePassword { get; set; }

    public string? ReturnUrl { get; set; }
}