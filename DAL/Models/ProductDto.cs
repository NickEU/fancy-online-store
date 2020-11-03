using System;

namespace DAL.Models
{
    public class ProductDto
    {
        public string BrandName { get; set; }
        public ClothingType Type { get; set; }
        public Guid ProductId { get; set; }
}
}
