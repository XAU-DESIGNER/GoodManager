using GoodManager.Domain.Enums.Accounting;

namespace GoodManager.Domain.DTOs.ViewModels.Accounting.Costs;

public class CostDetailsForFilterViewModel
{
    public int Id { get; set; }
    public string? Amount { get; set; }
    public CostTypes Type { get; set; }

    public string? CreateDateOnJalali { get; set; }
}