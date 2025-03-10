using GoodManager.Domain.Enums.LangCenter;
using GoodManager.Domain.Models.Common;

namespace GoodManager.Domain.Models.LangCenter;

public class Word : AuditBaseEntity
{
    #region Properties

    public string? Title { get; set; }
    public string? Meaning { get; set; }
    public WordType WordType { get; set; }

    #endregion
}