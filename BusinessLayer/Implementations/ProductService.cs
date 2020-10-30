using Autofac;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class ProductService : IProductService
    {
        public IReadOnlyCollection<string> GetAllBrands()
        {
            var container = InitBL.Container;
            using (var scope = container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IProductRepo>();
                return repo.GetAllBrands();
            }
        }
    }
}
