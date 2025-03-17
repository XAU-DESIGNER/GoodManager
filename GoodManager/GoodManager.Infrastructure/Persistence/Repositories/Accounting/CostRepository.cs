using GoodManager.Domain.Interfaces.Accounting;
using GoodManager.Domain.Models.Accounting;
using GoodManager.Infrastructure.Persistence.Repositories.Common;

namespace GoodManager.Infrastructure.Persistence.Repositories.Accounting;

public class CostRepository(GoodManagerDbContext context) : EfRepository<Cost>(context), ICostRepository;