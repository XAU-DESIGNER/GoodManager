using GoodManager.Domain.DTOs.ViewModels.Common;
using Mapster;

namespace GoodManager.Web.Extensions;

public static class UserExtensions
{
    public static UserIdentitiesViewModel? GetUserIdentities(this object? httpContextItem)
    {
        if (httpContextItem == null) return null;

        try
        {
            return httpContextItem.Adapt<UserIdentitiesViewModel>();
        }
        catch
        {
            return null;
        }
    }
}