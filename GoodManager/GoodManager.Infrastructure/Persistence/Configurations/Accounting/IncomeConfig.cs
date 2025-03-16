using GoodManager.Domain.Models.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodManager.Infrastructure.Persistence.Configurations.Accounting;

public class IncomeConfig : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.HasKey(x => x.Id);

        #region Properties



        #endregion

        #region Relations

        builder.HasOne(x => x.AccountingWallet)
            .WithMany(x => x.Incomes);

        #endregion
    }
}