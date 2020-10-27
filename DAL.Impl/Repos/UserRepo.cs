using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl.Repos
{
    class UserRepo : IUserRepo
    {
        public IReadOnlyCollection<string> GetNames()
        {
            return new List<string> { "Smith", "Wilson", "King" };
        }
    }
}
