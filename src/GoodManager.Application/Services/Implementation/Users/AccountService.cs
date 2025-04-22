using GoodManager.Application.Security;
using GoodManager.Application.Services.Interfaces.Users;
using GoodManager.Domain.Common;
using GoodManager.Domain.DTOs.ViewModels.Account;
using GoodManager.Domain.Interfaces.Users;
using GoodManager.Domain.Models.Users;
using Mapster;

namespace GoodManager.Application.Services.Implementation.Users;

public class AccountService(IUserRepository userRepository) : IAccountService
{
    public async Task<Result> RegisterAsync(RegisterViewModel model)
    {
        #region Sanitize

        model.Email = model.Email!.SanitizeTextAndTrim();
        model.Password = model.Password!.SanitizeTextAndTrim();
        model.UserName = model.UserName!.SanitizeTextAndTrim();

        #endregion

        #region Validation

        bool isExist = await userRepository.AnyAsync(user => user.UserName == model.UserName!.Trim());
        if (isExist) return Result.Failure<User>(string.Format(ErrorMessages.AlreadyExistError, "نام کاربـری"));

        isExist = await userRepository.AnyAsync(user => user.Email == model.Email!.Trim());
        if (isExist) return Result.Failure<User>(string.Format(ErrorMessages.AlreadyExistError, "ایمیــل"));

        #endregion

        model.Password = PasswordHelper.EncodePasswordSHA256(model.Password!);

        #region Map and insert

        var user = model.Adapt<User>();

        await userRepository.InsertAsync(user);
        await userRepository.SaveChangesAsync();

        #endregion

        return Result.Success(value: user, "حساب شما ساخته شد");
    }

    public async Task<Result<UserLoginInformationViewModel>> CheckAndGetUserForLoginAsync(LoginViewModel model)
    {
        model.UserNameOrEmail = model.UserNameOrEmail!.SanitizeTextAndTrim();

        var user = await userRepository.FirstOrDefaultAsync(user => user.Email == model.UserNameOrEmail && !user.IsDeleted) ??
            await userRepository.FirstOrDefaultAsync(user => user.UserName == model.UserNameOrEmail && !user.IsDeleted);

        if (user is null || user.Password != PasswordHelper.EncodePasswordSHA256(model.Password!))
            return Result.Failure<UserLoginInformationViewModel>(message: ErrorMessages.NotFoundError);

        //if (!user.IsEmailActive) return Result.Failure(ErrorMessages.AccountIsNotActive);

        return Result.Success(user.Adapt<UserLoginInformationViewModel>(),
            $"{user.UserName} عزیز خوش آمدید!");
    }
}