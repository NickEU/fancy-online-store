namespace DAL.Impl.Repos.EF.Models
{
    internal class ProductBrand
    {
        public int ProductBrandId { get; set; }
        public string BrandName { get; set; }
        public string HQLocation { get; set; }
        public byte[] Image { get; set; }
    }
}
