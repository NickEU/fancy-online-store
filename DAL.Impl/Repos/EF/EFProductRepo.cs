using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;

namespace DAL.Impl.Repos.EF
{
    public class EFProductRepo : IProductRepo
    {
        private readonly ProductDbContext _dbContext = new ProductDbContext();
        public EFProductRepo()
        {
            Database.SetInitializer(new ProductDbInitializer());
        }
        public IReadOnlyCollection<string> GetAllBrands()
        {
            return _dbContext.Brands.Select(brand => brand.BrandName).ToList();
        }
    }
}
