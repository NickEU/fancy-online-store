using System.Collections.Generic;
using DAL.Models;

namespace BusinessLayer.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProductsWithClothingType(ClothingType clothingType);
    }
}
