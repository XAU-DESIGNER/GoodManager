namespace GoodManager.Domain.Common.Filter;

public abstract class BasePaging<TEntity>
{
    #region Constructor

    public BasePaging()
    {
        CurrentPage = 1;
        TakeEntity = 10;
        HowManyShowPageAfterAndBefore = 5;
        Entities = new List<TEntity>();
    }

    #endregion

    #region Properties

    public int CurrentPage { get; set; }

    public int PageCount { get; set; }

    public int AllEntitiesCount { get; set; }

    public int StartPage { get; set; }

    public int EndPage { get; set; }

    public int TakeEntity { get; set; } = 20;

    public int SkipEntity { get; set; }

    public int HowManyShowPageAfterAndBefore { get; set; }

    public int Counter { get; set; }

    public List<TEntity> Entities { get; set; }

    #endregion
}