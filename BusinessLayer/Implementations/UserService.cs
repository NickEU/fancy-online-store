using System.Collections.Generic;
using BusinessLayer.Interfaces;
using DAL.Interfaces;

namespace BusinessLayer.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _repo;
        public UserService(IUnitOfWork repo)
        {
            _repo = repo;
        }
        public IReadOnlyCollection<string> GetNames()
        {
            return _repo.UserRepo.GetNames();
        }
    }
}

