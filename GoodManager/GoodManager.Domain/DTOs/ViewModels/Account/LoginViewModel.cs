using GoodManager.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace GoodManager.Domain.DTOs.ViewModels.Account;

public class LoginViewModel
{
    public int? Id { get; set; }

    [Display(Name = "نام کاربری یا ایمیل")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [RegularExpression(@"^[a-zA-Z0-9@\.]+$", ErrorMessage = ErrorMessages.RegexIncorrectFormat)]
    [MaxLength(30, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? UserNameOrEmail { get; set; }

    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(350, ErrorMessage = ErrorMessages.MaxLengthError)]
    [MinLength(8, ErrorMessage = ErrorMessages.MinLengthError)]
    public string? Password { get; set; }

    public string? ReturnUrl { get; set; }

    [Display(Name = "مرا به خاطر بسپار")]
    public bool RememberMe { get; set; }
}