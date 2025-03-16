using GoodManager.Domain.Models.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodManager.Infrastructure.Persistence.Configurations.Accounting;

internal class AccountingWalletConfig : IEntityTypeConfiguration<AccountingWallet>
{
    public void Configure(EntityTypeBuilder<AccountingWallet> builder)
    {
        builder.HasKey(x=> x.Id);

        #region Properties



        #endregion

        #region Relations

        builder.HasMany(x => x.Costs)
            .WithOne(x=>x.AccountingWallet);

        builder.HasMany(x => x.Incomes)
            .WithOne(x => x.AccountingWallet);

        #endregion
    }
}
