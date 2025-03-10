using GoodManager.Domain.Models.Common;

namespace GoodManager.Domain.Models.Users;

public class User : AuditBaseEntity
{
    #region Properties

    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? AvatarName { get; set; }

    #endregion

    #region Relations



    #endregion
}