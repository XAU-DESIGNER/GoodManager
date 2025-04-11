using GoodManager.Domain.Enums.LangCenter;
using GoodManager.Domain.Models.Common;
using GoodManager.Domain.Models.Users;

namespace GoodManager.Domain.Models.LangCenter;

public class Word : AuditBaseEntity
{
    #region Properties

    public int UserId { get; set; }
    public string? Title { get; set; }
    public string? Meaning { get; set; }
    public string? Descriptions { get; set; }
    public WordType WordType { get; set; }
    public VerbType? VerbType { get; set; }

    #endregion

    #region Relations

    public User? User { get; set; }

    #endregion
}