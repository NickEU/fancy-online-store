using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BusinessLayer.Interfaces;
using DAL.Interfaces;

namespace BusinessLayer.Implementations
{
    public class BLServices : IServices
    {
        protected readonly IUnitOfWork Repo;
        public BLServices(IBrandService brand, IProductService product, IUserService user)
        {
            var container = InitBL.Container;
            var scope = container.BeginLifetimeScope();
            Repo = scope.Resolve<IUnitOfWork>();
            Brand = brand;
            Product = product;
            User = user;
        }

        public IBrandService Brand { get; }
        public IProductService Product { get; }
        public IUserService User { get; }
    }
}
