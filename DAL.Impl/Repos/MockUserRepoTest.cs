using System;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Models;

namespace DAL.Impl.Repos
{
    public class MockUserRepoTest : IUserRepo
    {
        public IReadOnlyCollection<string> GetNames()
        {
            return new List<string> { "Swift", "Taylor", "Singletary" };
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
