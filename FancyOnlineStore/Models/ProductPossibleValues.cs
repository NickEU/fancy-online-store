using System;
using System.Collections.Generic;
using DAL.Models;

namespace FancyOnlineStore.Models
{
    public static class ProductPossibleValues
    {
        public static IReadOnlyCollection<BrandViewModel> Brands = null;
        public static Size[] Sizes = (Size[]) Enum.GetValues(typeof(Size));
        public static ClothingType[] Types = (ClothingType[]) Enum.GetValues(typeof(ClothingType));
    }
}