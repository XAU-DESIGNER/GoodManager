using GoodManager.Domain.Models.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodManager.Infrastructure.Persistence.Configurations.Accounting;

public class CostConfig : IEntityTypeConfiguration<Cost>
{
    public void Configure(EntityTypeBuilder<Cost> builder)
    {
        builder.HasKey(x => x.Id);

        #region Properties



        #endregion

        #region Relations

        builder.HasOne(x => x.AccountingWallet)
            .WithMany(x => x.Costs);

        #endregion
    }
}