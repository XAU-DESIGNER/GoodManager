using GoodManager.Domain.Models.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodManager.Infrastructure.Persistence.Configurations.Accounting;

public class AccountingTransactionConfig : IEntityTypeConfiguration<AccountingTransaction>
{
    public void Configure(EntityTypeBuilder<AccountingTransaction> builder)
    {
        builder.HasKey(x => x.Id);

        #region Properties



        #endregion

        #region Relations

        builder.HasOne(x => x.User)
            .WithMany(x => x.AccountingTransactions)
            .HasForeignKey(x => x.UserId)
            .IsRequired(true);

        #endregion
    }
}