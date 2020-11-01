using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Impl.Repos.EF.Models
{
    internal enum Size
    {
        S, M, L, XL
    }

    internal class ClothingItem
    {
        public int ClothingItemId { get; set; }
        public string Type { get; set; }

        [ForeignKey("ProductBrand")]
        public int ProductBrandId { get; set; }
        public Size Size { get; set; }

        public virtual ProductBrand ProductBrand { get; set; }
    }
}
