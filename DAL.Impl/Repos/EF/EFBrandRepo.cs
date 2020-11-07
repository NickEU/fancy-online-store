using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Impl.Repos.EF
{
    internal class EFBrandRepo : IBrandRepo
    {
        public IMapper Mapper { get; }
        private readonly EFDbContext _dbContext;

        internal EFBrandRepo(EFDbContext dbContext, IMapper mapper)
        {
            Mapper = mapper;
            _dbContext = dbContext;
        }

        public IEnumerable<BrandDto> GetAll()
        {
            return Mapper.ProjectTo<BrandDto>(_dbContext.Brands);
        }

        public IEnumerable<BrandDto> Find(Expression<Func<BrandDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(BrandDto entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(BrandDto entity)
        {
            throw new NotImplementedException();
        }
    }
}