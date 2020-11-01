using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Impl.Repos
{
    class UnitOfWork : IUnitOfWork
    {
        public IProductRepo ProductRepo { get; }
        public IUserRepo UserRepo { get; }
        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
