using GoodManager.Domain.Interfaces.Accounting;
using GoodManager.Domain.Models.Accounting;
using GoodManager.Infrastructure.Persistence.Repositories.Common;

namespace GoodManager.Infrastructure.Persistence.Repositories.Accounting;

public class AccountingTransactionRepository(GoodManagerDbContext context) : EfRepository<AccountingTransaction>(context), IAccountingTransactionRepository;