namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepo ProductRepo { get; }
        IUserRepo UserRepo { get; }
        IBrandRepo BrandRepo { get; }

        void SaveChanges();
    }
}
