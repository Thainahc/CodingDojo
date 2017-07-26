using System;

namespace Sommus.CodingDojo.Domain.Interfaces.Repositories
{
    public interface IDataContext : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void Finally();
    }
}