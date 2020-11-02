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
        private static readonly Random Rnd = new Random();
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
            var clothesDbSet = _context.Clothes;
            var brands = _context.Brands
                .Select(e => e.BrandId).ToList();
            clothesDbSet.Add(new Product
            {
                Type = ClothingType.Shirt,
                Size = Size.L,
                BrandId = GuidOfRandomBrand(brands)
            });
            clothesDbSet.Add(new Product
            {
                Type = ClothingType.Shirt,
                Size = Size.L,
                BrandId = GuidOfRandomBrand(brands)
            });
            clothesDbSet.Add(new Product
            {
                Type = ClothingType.Jacket,
                Size = Size.XL,
                BrandId = GuidOfRandomBrand(brands)
            });
            clothesDbSet.Add(new Product
            {
                Type = ClothingType.Shirt,
                Size = Size.S,
                BrandId = GuidOfRandomBrand(brands)
            });
            _context.SaveChanges();
        }
        private static Guid GuidOfRandomBrand(IReadOnlyCollection<Guid> brands)
        {
            return brands.ElementAt(Rnd.Next(brands.Count));
        }
    }
}
