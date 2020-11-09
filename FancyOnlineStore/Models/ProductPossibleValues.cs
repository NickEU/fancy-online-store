using System;
using System.Collections.Generic;
using DAL.Models;

namespace FancyOnlineStore.Models
{
    public static class ProductPossibleValues
    {
        public static IReadOnlyCollection<BrandViewModel> Brands = null;
        public static Size[] Sizes = GetValues<Size>();
        public static ClothingType[] Types = GetValues<ClothingType>();

        private static T[] GetValues<T>()
        {
            return (T[]) Enum.GetValues(typeof(T));
        }
    }
}