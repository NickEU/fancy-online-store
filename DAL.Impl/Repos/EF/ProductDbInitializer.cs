﻿using DAL.Impl.Repos.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl.Repos.EF
{
    class ProductDbInitializer : DropCreateDatabaseAlways<ProductDbContext>
    {
        protected override void Seed(ProductDbContext context)
        {
            context.Brands.Add(new ProductBrand { BrandName = "Nike", HQLocation = "USA" });
            context.Brands.Add(new ProductBrand { BrandName = "Ralph Lauren", HQLocation = "USA" });
            context.Brands.Add(new ProductBrand { BrandName = "Louis Vuitton", HQLocation = "France" });
            context.SaveChanges();

            context.Clothes.Add(new ClothingItem { Type = "shirt", Size = Size.L, ProductBrandId = 1});
            context.Clothes.Add(new ClothingItem { Type = "shirt", Size = Size.L, ProductBrandId = 2 });
            context.Clothes.Add(new ClothingItem { Type = "shirt", Size = Size.XL, ProductBrandId = 3 });
            context.Clothes.Add(new ClothingItem { Type = "shirt", Size = Size.S, ProductBrandId = 2 });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
