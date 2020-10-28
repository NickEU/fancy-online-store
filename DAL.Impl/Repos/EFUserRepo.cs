using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
