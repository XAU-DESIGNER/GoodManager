using GoodManager.Application.Services.Interfaces.Users;
using GoodManager.Domain.DTOs.ViewModels.Common;
using GoodManager.Domain.Interfaces.Users;
using Mapster;

namespace GoodManager.Application.Services.Implementation.Users;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<UserIdentitiesViewModel?> GetUserIdentitiesById(int userId)
    {
        var result = await userRepository.GetByIdAsync(userId);

        return result.Adapt<UserIdentitiesViewModel>();
    }
}