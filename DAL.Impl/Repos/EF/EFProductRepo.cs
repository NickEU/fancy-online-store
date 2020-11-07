﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
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

        public IEnumerable<ProductDto> GetAll()
        {
            return Mapper
                .ProjectTo<ProductDto>(_dbContext.Clothes)
                .ToList();
        }

        public IEnumerable<ProductDto> Find(Expression<Func<ProductDto, bool>> predicate)
        {
            return GetAll()
                .Where(predicate.Compile());
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