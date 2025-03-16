using GoodManager.Domain.Models.Accounting;
using GoodManager.Domain.Models.LangCenter;
using GoodManager.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace GoodManager.Infrastructure.Persistence;

public class GoodManagerDbContext(DbContextOptions<GoodManagerDbContext> options) : DbContext(options)
{
    #region Dbsets

    #region Users

    public DbSet<User> Users { get; set; }

    #endregion

    #region Lang center

    public DbSet<Word> Words { get; set; }

    #endregion

    #region Accounting

    public DbSet<AccountingWallet> AccountingWallets { get; set; }
    public DbSet<Income> Incomes{ get; set; }
    public DbSet<Cost> Costs { get; set; }

    #endregion

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoodManagerDbContext).Assembly);
    }
}