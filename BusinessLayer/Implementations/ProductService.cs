using Autofac;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class ProductService : IProductService
    {
        public IReadOnlyCollection<string> GetNamesOfAllBrands()
        {
            var container = InitBL.Container;
            using (var scope = container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IProductRepo>();
                return repo.GetAll()
                    .Select(product => product.BrandName)
                    .Distinct()
                    .ToList();
            }
        }
    }
}
