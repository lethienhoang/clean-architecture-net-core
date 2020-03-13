using Hx.Core.Models;
using Hx.Core.Repositories;
using Hx.Domain.Db;

namespace Hx.Domain.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DomainContext context) : base(context)
        {
        }
    }
}
