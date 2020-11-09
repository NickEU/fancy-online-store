using System;
using System.Collections.Generic;
using DAL.Models;

namespace BusinessLayer.Interfaces
{
    public interface IBrandService
    {
        IEnumerable<BrandDto> GetBrands();

        Guid GetBrandIdFromName(string brandName);
    }
}
