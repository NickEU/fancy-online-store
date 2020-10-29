using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Impl.Repos
{
    class EFUserRepo : IUserRepo
    {
        public IReadOnlyCollection<string> GetNames()
        {
            throw new NotImplementedException();
        }
    }
}
