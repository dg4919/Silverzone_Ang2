using System;

namespace Silverzone.Data
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
