using System.Collections.Generic;
using System.Linq;
using DAL.Models;

namespace BusinessLayer.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProductsWithClothingType(ClothingType clothingType);
    }
}
