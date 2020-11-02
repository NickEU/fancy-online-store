using System;
using System.Data.Entity;
using DAL.Interfaces;

namespace DAL.Impl.Repos.EF
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        internal readonly EFDbContext DbContext = new EFDbContext();

        public EFUnitOfWork()
        {
            Database.SetInitializer(new EFDbInitializer());
            ProductRepo = new EFProductRepo(DbContext);
            UserRepo = null;
        }

        public IProductRepo ProductRepo { get; }
        public IUserRepo UserRepo { get; }
        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
