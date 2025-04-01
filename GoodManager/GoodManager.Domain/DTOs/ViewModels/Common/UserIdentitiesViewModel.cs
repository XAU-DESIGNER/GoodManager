namespace GoodManager.Domain.DTOs.ViewModels.Common;

public class UserIdentitiesViewModel
{
    public int? Id { get; set; }
    public int? AccountingWalletId { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public bool IsDelete { get; set; }
}