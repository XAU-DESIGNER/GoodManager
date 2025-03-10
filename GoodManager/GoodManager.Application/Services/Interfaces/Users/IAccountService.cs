using GoodManager.Domain.Common;
using GoodManager.Domain.DTOs.ViewModels.Account;

namespace GoodManager.Application.Services.Interfaces.Users;

public interface IAccountService
{
    Task<Result> RegisterAsync(RegisterViewModel model);
    Task<Result<UserLoginInformationViewModel>> CheckAndGetUserForLoginAsync(LoginViewModel model);
}