using System;

namespace DAL.Models
{
    public class Product
    {
        public string BrandName { get; set; }
        public ClothingType Type { get; set; }
        public Guid ProductId { get; set; }
}
}
