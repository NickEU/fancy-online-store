﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<ProductDto> GetAll()
        {
            var result = new List<ProductDto>();
            foreach (var product in _dbContext.Clothes)
            {
                var item = new ProductDto
                {
                    BrandName = _dbContext.Brands.Find(product.BrandId)?.BrandName,
                    Type = product.Type,
                    ProductId = product.ProductId
                };
                result.Add(item);
            }

            return result;
        }

        public IEnumerable<ProductDto> Find(Expression<Func<ProductDto, bool>> predicate)
        {
            return _dbContext.Clothes
                .Select(p => new ProductDto
                {
                    BrandName = _dbContext.Brands.Find(p.BrandId).BrandName,
                    ProductId = p.ProductId,
                    Type = p.Type
                })
                .Where(predicate)
                .ToList();
        }

        public void Add(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
