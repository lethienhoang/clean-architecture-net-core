using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hx.Core;
using Hx.Core.Repositories;
using Hx.Domain.Db;
using Hx.Domain.Repositories;

namespace Hx.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private DomainContext _context;

        private IUserRoleRepository _userRoleRepository;
        private IRoleRepository _roleRepository;
        private IRefreshTokenRepository _refreshTokenRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(DomainContext context)
        {
            _context = context;
        }

        //public IUserRoleRepository Accounts => _userRepository = _userRepository ?? new UserRepository(_context);

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
