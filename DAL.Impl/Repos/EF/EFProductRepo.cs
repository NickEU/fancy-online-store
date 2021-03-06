﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using DAL.Impl.Repos.EF.Models;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Impl.Repos.EF
{
    internal class EFProductRepo : IProductRepo
    {
        public IMapper Mapper { get; }
        private readonly EFDbContext _dbContext;

        internal EFProductRepo(EFDbContext dbContext, IMapper mapper)
        {
            Mapper = mapper;
            _dbContext = dbContext;
        }

        public IQueryable<ProductDto> GetAll()
        {
            return Mapper
                .ProjectTo<ProductDto>(_dbContext.Clothes);
        }

        public IQueryable<ProductDto> Find(Expression<Func<ProductDto, bool>> predicate)
        {
            return GetAll()
                .Where(predicate);
        }

        public void Add(ProductDto entity)
        {
            var product = Mapper.Map<Product>(entity);
            _dbContext.Clothes.Add(product);
        }

        public void Remove(ProductDto entity)
        {
            var product = Mapper.Map<Product>(entity);
            _dbContext.Entry(product).State = EntityState.Deleted;
        }
    }
}