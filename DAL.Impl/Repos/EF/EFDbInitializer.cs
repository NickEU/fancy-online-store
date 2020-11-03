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
                .Select(e => e.BrandId)
                .ToList();

            for (var i = 0; i < 10; i++)
            {
                clothesDbSet.Add(new Product
                {
                    Type = GetRandomValueFromEnum<ClothingType>(),
                    Size = GetRandomValueFromEnum<Size>(),
                    BrandId = GetGuidOfRandomBrand(brands)
                });
            }

            _context.SaveChanges();
        }
        private static Guid GetGuidOfRandomBrand(IReadOnlyCollection<Guid> brands)
        {
            return brands.ElementAt(Rnd.Next(brands.Count));
        }
        private static T GetRandomValueFromEnum<T>()
        {
            var members = Enum.GetValues(typeof(T));
            return (T) members.GetValue(Rnd.Next(members.Length));
        }
    }
}
