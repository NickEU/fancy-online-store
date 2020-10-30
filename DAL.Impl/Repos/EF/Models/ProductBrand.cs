using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl.Repos.EF.Models
{
    class ProductBrand
    {
        public int ProductBrandId { get; set; }
        public string BrandName { get; set; }
        public string HQLocation { get; set; }
        public byte[] Image { get; set; }
    }
}
