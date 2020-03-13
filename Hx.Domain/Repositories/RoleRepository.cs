using Hx.Core.Models;
using Hx.Core.Repositories;
using Hx.Domain.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hx.Domain.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(DomainContext context) : base(context)
        {
        }
    }
}
