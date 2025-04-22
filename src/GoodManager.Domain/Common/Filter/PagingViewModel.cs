namespace GoodManager.Domain.Common.Filter;

public class PagingViewModel
{
    public int Page { get; set; }

    public int StartPage { get; set; }

    public int EndPage { get; set; }

    public string? FormId { get; set; }
}