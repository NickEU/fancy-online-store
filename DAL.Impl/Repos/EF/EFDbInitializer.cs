using DAL.Impl.Repos.EF.Models;
using System.Data.Entity;
using System.Linq;
using DAL.Models;
using System;
using System.Collections.Generic;
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
            var brands = _context.Brands
                .Select(e => e.BrandId)
                .ToList();

            const int productCount = 5000;
            var randomProducts = new Product[productCount];

            for (var i = 0; i < productCount; i++)
            {
                randomProducts[i] = GenerateRandomProduct(brands);
            }

            // better but still slow, need to find an alternative
            _context.Clothes.AddRange(randomProducts);
            _context.SaveChanges();
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
