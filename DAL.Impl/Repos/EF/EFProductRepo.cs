using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Impl.Repos.EF
{
    public class EFProductRepo : IProductRepo
    {
        private readonly ProductDbContext _dbContext = new ProductDbContext();
        public EFProductRepo()
        {
            Database.SetInitializer(new ProductDbInitializer());
        }
        public IReadOnlyCollection<string> GetAllBrands()
        {
            return _dbContext.Brands.Select(brand => brand.BrandName).ToList();
        }

        public IEnumerable<Product> GetAll()
        {
            var result = new List<Product>();
            foreach (var product in _dbContext.Clothes)
            {
                var item = new Product
                {
                    BrandName = _dbContext.Brands.Find(product.ProductBrandId)?.BrandName,
                    Type = product.Type,
                    ProductId = product.ProductId
                };
                result.Add(item);
            }

            return result;
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
