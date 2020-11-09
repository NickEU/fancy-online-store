using System;
using System.Linq;
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

        public IQueryable<BrandDto> GetAll()
        {
            return Mapper.ProjectTo<BrandDto>(_dbContext.Brands);
        }

        public IQueryable<BrandDto> Find(Expression<Func<BrandDto, bool>> predicate)
        {
            return GetAll()
                .Where(predicate);
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