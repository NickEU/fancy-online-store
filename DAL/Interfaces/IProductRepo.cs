using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IProductRepo : IRepository
    {
        IReadOnlyCollection<string> GetAllBrands();
    }
}
