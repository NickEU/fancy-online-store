using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl.Repos.EF.Models
{
    enum Size
    {
        S, M, L, XL
    }
    class ClothingItem
    {
        public int ClothingItemId { get; set; }
        public string Type { get; set; }

        [ForeignKey("ProductBrand")]
        public int ProductBrandId { get; set; }
        public Size Size { get; set; }

        public virtual ProductBrand ProductBrand { get; set; }
    }
}
