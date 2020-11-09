using System;
using System.Collections.Generic;
using DAL.Models;

namespace FancyOnlineStore.Models
{
    public class ProductViewModel
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public ClothingType Type { get; set; }
        public Size Size { get; set; }
        public Guid ProductId { get; set; }
        public static IReadOnlyCollection<BrandViewModel> AvailableBrands { get; set; }
    }
}