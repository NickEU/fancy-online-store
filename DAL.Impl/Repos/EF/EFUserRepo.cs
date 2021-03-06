﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Impl.Repos.EF
{
    internal class EFUserRepo : IUserRepo
    {
        public IReadOnlyCollection<string> GetNames()
        {
            //stub
            return new List<string> { "Smith", "Wilson", "King" };
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> Find(Expression<Func<User, bool>> predicate)
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
