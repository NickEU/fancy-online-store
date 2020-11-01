using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Impl.Repos.EF.Models
{
    internal class ProductImage
    {
        public int ProductImageId { get; set; }
        [ForeignKey("ClothingItem")]
        public int ClothingItemId { get; set; }
        public byte[] Image { get; set; }

        public virtual ClothingItem ClothingItem { get; set; }
    }
}
