using BusinessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class BLServices : IServices
    {
        public BLServices(IBrandService brand, IProductService product, IUserService user)
        {
            Brand = brand;
            Product = product;
            User = user;
        }

        public IBrandService Brand { get; }
        public IProductService Product { get; }
        public IUserService User { get; }
    }
}
