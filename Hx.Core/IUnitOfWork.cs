using System;
using System.Threading.Tasks;

namespace Hx.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit();
    }
}
