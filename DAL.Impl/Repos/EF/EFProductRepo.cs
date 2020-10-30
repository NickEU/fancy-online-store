using DAL.Impl.Repos.EF;
using DAL.Impl.Repos.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Impl.Repos
{
    public class EFProductRepo : IProductRepo
    {
        private readonly ProductDbContext dbContext = new ProductDbContext();
        public EFProductRepo()
        {
            Database.SetInitializer(new ProductDbInitializer());
        }
        public IReadOnlyCollection<string> GetAllBrands()
        {
            var brands = dbContext.Brands;
            var result = new List<string>();
            foreach(var brand in brands)
            {
                result.Add(brand.BrandName);
            }
            return result;
        }
    }
}
