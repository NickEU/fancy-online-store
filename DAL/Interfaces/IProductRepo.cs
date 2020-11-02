using DAL.Models;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IProductRepo : IRepository<Product>
    {
        IReadOnlyCollection<string> GetAllBrands();
    }
}
