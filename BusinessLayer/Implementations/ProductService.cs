using System.Collections.Generic;
using DAL.Interfaces;
using System.Linq;
using BusinessLayer.Interfaces;
using DAL.Models;

namespace BusinessLayer.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _repo;
        public ProductService(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public IEnumerable<ProductDto> GetProductsWithClothingType(ClothingType clothingType)
        {
            return _repo.ProductRepo
                .Find(p => p.Type == clothingType)
                .ToList();
        }

        public void AddProduct(ProductDto entity)
        {
            _repo.ProductRepo.Add(entity);
        }
    }
}
