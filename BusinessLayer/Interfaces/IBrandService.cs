using System.Collections.Generic;
using DAL.Models;

namespace BusinessLayer.Interfaces
{
    public interface IBrandService
    {
        IReadOnlyCollection<BrandDto> GetBrands();
    }
}
