using GoodManager.Domain.Interfaces.Users;
using GoodManager.Domain.Models.Users;
using GoodManager.Infrastructure.Persistence.Repositories.Common;

namespace GoodManager.Infrastructure.Persistence.Repositories.Users;

public class UserRepository(GoodManagerDbContext context) : EfRepository<User>(context), IUserRepository;