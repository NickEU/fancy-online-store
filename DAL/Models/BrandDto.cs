using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class BrandDto
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<ProductDto> Products { get; set; }
    }
}