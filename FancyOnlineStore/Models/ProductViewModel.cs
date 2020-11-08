using DAL.Models;

namespace FancyOnlineStore.Models
{
    public class ProductViewModel
    {
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public ClothingType Type { get; set; }
    }
}