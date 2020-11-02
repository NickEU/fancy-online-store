using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace DAL.Impl.Repos.EF.Models
{
    internal class ClothingItem
    {
        [Key]
        public int ProductId { get; set; }
        public ClothingType Type { get; set; }
        public string ProductName { get; set; }

        [ForeignKey("ProductBrand")]
        public int ProductBrandId { get; set; }
        public Size Size { get; set; }

        public virtual ProductBrand ProductBrand { get; set; }
    }
}
