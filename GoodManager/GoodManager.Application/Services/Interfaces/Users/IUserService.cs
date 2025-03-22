using GoodManager.Domain.DTOs.ViewModels.Common;

namespace GoodManager.Application.Services.Interfaces.Users;

public interface IUserService
{
    Task<UserIdentitiesViewModel?> GetUserIdentitiesById(int userId);
}