using GoodManager.Domain.Interfaces.LangCenter;
using GoodManager.Domain.Models.LangCenter;
using GoodManager.Infrastructure.Persistence.Repositories.Common;

namespace GoodManager.Infrastructure.Persistence.Repositories.LangCenter;

public class WordRepository(GoodManagerDbContext context) : EfRepository<Word>(context), IWordRepository;