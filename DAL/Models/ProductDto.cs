using System;

namespace DAL.Models
{
    public class ProductDto
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public ClothingType Type { get; set; }
        public Size Size { get; set; }
        public Guid ProductId { get; set; }
    }
}
