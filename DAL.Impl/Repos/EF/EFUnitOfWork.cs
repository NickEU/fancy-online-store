using System;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using AutoMapper;
using DAL.Impl.Repos.EF.Models;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Impl.Repos.EF
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        internal readonly EFDbContext DbContext = new EFDbContext();

        public EFUnitOfWork()
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<Product, ProductDto>());
            Database.SetInitializer(new EFDbInitializer());
            ProductRepo = new EFProductRepo(DbContext);
            UserRepo = new EFUserRepo();
            BrandRepo = new EFBrandRepo(DbContext);
        }

        public IProductRepo ProductRepo { get; }
        public IUserRepo UserRepo { get; }
        public IBrandRepo BrandRepo { get; }

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
