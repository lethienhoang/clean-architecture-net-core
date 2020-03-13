using Framework.Sql.Infrastructure;
using Hx.Core.Models;
using Hx.Core.Repositories;
using Hx.Domain.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hx.Domain.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(DomainContext context) : base(context)
        {
        } 
    }
}
