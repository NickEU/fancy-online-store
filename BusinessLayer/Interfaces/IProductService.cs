using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IProductService
    {
        IReadOnlyCollection<string> GetAllBrands();
    }
}
