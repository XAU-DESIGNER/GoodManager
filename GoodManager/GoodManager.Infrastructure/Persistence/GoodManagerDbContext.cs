using GoodManager.Domain.Models.LangCenter;
using GoodManager.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace GoodManager.Infrastructure.Persistence;

public class GoodManagerDbContext(DbContextOptions<GoodManagerDbContext> options) : DbContext(options)
{
    #region Dbsets

    #region Users

    public DbSet<User> Users { get; set; }
    public DbSet<Word> Words { get; set; }

    #endregion

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoodManagerDbContext).Assembly);
    }
}