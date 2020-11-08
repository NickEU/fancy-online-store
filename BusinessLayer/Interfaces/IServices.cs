namespace BusinessLayer.Interfaces
{
    public interface IServices
    {
        IBrandService Brand { get; }
        IProductService Product { get; }
        IUserService User { get; }
    }
}