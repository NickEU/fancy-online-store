using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DAL.Interfaces;

namespace BusinessLayer.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _repo;
        public BrandService(IUnitOfWork repo)
        {
            _repo = repo;
        }
        public IReadOnlyCollection<string> GetNames()
        {
            return _repo.BrandRepo.GetAll()
                .Select(b => b.BrandName)
                .ToList();
        }
    }
}
