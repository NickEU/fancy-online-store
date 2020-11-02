using System;
using DAL.Interfaces;

namespace DAL.Impl.Repos
{
    class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IProductRepo ProductRepo { get; }
        public IUserRepo UserRepo { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
