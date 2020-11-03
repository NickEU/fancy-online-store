using Autofac;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Interfaces;
using System;
using DAL.Models;

namespace BusinessLayer.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _repo;
        public ProductService()
        {
            var container = InitBL.Container;
            var scope = container.BeginLifetimeScope();
            _repo = scope.Resolve<IUnitOfWork>();
        }

        public IReadOnlyCollection<string> GetNamesOfAllBrands()
        {
            return _repo.ProductRepo.GetAll()
                .Select(product => product.BrandName)
                .Distinct()
                .ToList();
        }

        public ProductDto FindProduct(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
