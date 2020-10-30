using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl.Repos.EF.Models
{
    class ProductImage
    {
        public int ProductImageId { get; set; }
        [ForeignKey("ClothingItem")]
        public int ClothingItemId { get; set; }
        public byte[] Image { get; set; }

        public virtual ClothingItem ClothingItem { get; set; }
    }
}
