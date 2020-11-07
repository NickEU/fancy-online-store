using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Impl.Repos.EF
{
    internal class EFBrandRepo : IBrandRepo
    {
        private readonly EFDbContext _dbContext;

        internal EFBrandRepo(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<BrandDto> GetAll()
        {
            return _dbContext.Brands
                .Select(b => new BrandDto
                {
                    BrandId = b.BrandId,
                    BrandName = b.BrandName,
                    Products = b.Products.Select(p =>
                            // TODO: Setup auto mapping.
                            new ProductDto
                            {
                                BrandName = b.BrandName,
                                ProductId = p.ProductId,
                                Type = p.Type
                            })
                        .ToList()
                })
                .ToList();
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