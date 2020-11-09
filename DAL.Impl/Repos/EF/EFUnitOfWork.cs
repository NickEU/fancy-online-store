using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
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
            if (EFDbState.NotInitialized)
            {
                InitializeDatabase();
            }

            var mapper = BuildAutomapperInstance();
            ProductRepo = new EFProductRepo(DbContext, mapper);
            UserRepo = new EFUserRepo();
            BrandRepo = new EFBrandRepo(DbContext, mapper);
        }

        public IProductRepo ProductRepo { get; }
        public IUserRepo UserRepo { get; }
        public IBrandRepo BrandRepo { get; }

        public void SaveChanges()
        {
            try
            {
                DbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //TODO: Solves conflicts when quickly executing two modifications
                //TODO: at the same time. Right now just ignores the second transaction.
                //TODO: Will run into issues later when multiple users are using the app.
            }
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        private static IMapper BuildAutomapperInstance()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Product, ProductDto>()
                        .ForMember(dto => dto.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName));
                    cfg.CreateMap<Brand, BrandDto>();
                    cfg.CreateMap<ProductDto, Product>();
                });

            return config.CreateMapper();
        }

        private void InitializeDatabase()
        {
            Database.SetInitializer(new EFDbInitializer());
            DbContext.Brands.First();
            EFDbState.NotInitialized = false;
        }
    }
}