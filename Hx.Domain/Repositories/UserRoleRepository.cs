using Hx.Core.Models;
using Hx.Core.Repositories;
using Hx.Domain.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hx.Domain.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DomainContext context) : base(context)
        {
        }
    }
}
