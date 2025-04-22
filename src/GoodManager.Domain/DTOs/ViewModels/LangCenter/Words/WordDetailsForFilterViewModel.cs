using GoodManager.Domain.Enums.LangCenter;

namespace GoodManager.Domain.DTOs.ViewModels.LangCenter.Words;

public class WordDetailsForFilterViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Meaning { get; set; }
    public WordType WordType { get; set; }

    public bool IsDeleted { get; set; }
}