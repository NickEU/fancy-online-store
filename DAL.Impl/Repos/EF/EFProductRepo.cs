using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Impl.Repos.EF
{
    internal class EFProductRepo : IProductRepo
    {
        private readonly EFDbContext _dbContext;

        internal EFProductRepo(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Product> GetAll()
        {
            var result = new List<Product>();
            foreach (var product in _dbContext.Clothes)
            {
                var item = new Product
                {
                    BrandName = _dbContext.Brands.Find(product.BrandId)?.BrandName,
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
