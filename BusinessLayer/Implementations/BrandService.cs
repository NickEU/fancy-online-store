using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BusinessLayer.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _repo;
        public BrandService(IUnitOfWork repo)
        {
            _repo = repo;
        }
        public IReadOnlyCollection<BrandDto> GetNames()
        {
            return _repo.BrandRepo.GetAll()
                .ToList();
        }
    }
}
