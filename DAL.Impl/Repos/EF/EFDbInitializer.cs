using DAL.Impl.Repos.EF.Models;
using System.Data.Entity;
using System.Linq;
using DAL.Models;
using System;
using System.Collections.Generic;
using EntityFramework.BulkInsert.Extensions;
using Product = DAL.Impl.Repos.EF.Models.Product;

namespace DAL.Impl.Repos.EF
{
    internal class EFDbInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        private EFDbContext _context;

        protected override void Seed(EFDbContext context)
        {
            _context = context;

            SeedBrands();
            SeedProducts();

            base.Seed(context);
        }
        private void SeedBrands()
        {
            var brandsDbSet = _context.Brands;
            brandsDbSet.Add(new Brand { BrandName = "Nike", HQLocation = "USA" });
            brandsDbSet.Add(new Brand { BrandName = "Ralph Lauren", HQLocation = "USA" });
            brandsDbSet.Add(new Brand { BrandName = "Louis Vuitton", HQLocation = "France" });
            _context.SaveChanges();
        }
        private void SeedProducts()
        {
            const int productCount = 5000;
            var randomProducts = GenerateRandomProducts(productCount);

            _context.BulkInsert(randomProducts);
            _context.SaveChanges();
        }

        private IEnumerable<Product> GenerateRandomProducts(int productCount)
        {
            var brands = _context.Brands
                .Select(e => e.BrandId)
                .ToList();

            var randomProducts = new List<Product>(productCount);

            for (var i = 0; i < productCount; i++)
            {
                randomProducts.Add(GenerateRandomProduct(brands));
            }

            return randomProducts;
        }

        private static Product GenerateRandomProduct(IReadOnlyCollection<Guid> brands)
        {
            return new Product
            {
                ProductName = Util.GenerateRandomProductName(),
                Type = Util.GetRandomValueFromEnum<ClothingType>(),
                Size = Util.GetRandomValueFromEnum<Size>(),
                BrandId = Util.GetGuidOfRandomBrand(brands)
            };
        }
    }
}
