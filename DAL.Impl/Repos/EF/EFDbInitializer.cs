﻿using DAL.Impl.Repos.EF.Models;
using System.Data.Entity;
using DAL.Models;

namespace DAL.Impl.Repos.EF
{
    internal class EFDbInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            context.Brands.Add(new ProductBrand { BrandName = "Nike", HQLocation = "USA" });
            context.Brands.Add(new ProductBrand { BrandName = "Ralph Lauren", HQLocation = "USA" });
            context.Brands.Add(new ProductBrand { BrandName = "Louis Vuitton", HQLocation = "France" });
            context.SaveChanges();

            context.Clothes.Add(new ClothingItem { Type = ClothingType.Shirt, Size = Size.L, ProductBrandId = 1});
            context.Clothes.Add(new ClothingItem { Type = ClothingType.Shirt, Size = Size.L, ProductBrandId = 2 });
            context.Clothes.Add(new ClothingItem { Type = ClothingType.Jacket, Size = Size.XL, ProductBrandId = 3 });
            context.Clothes.Add(new ClothingItem { Type = ClothingType.Shirt, Size = Size.S, ProductBrandId = 2 });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
