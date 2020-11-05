using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Implementations;

namespace BusinessLayer.Interfaces
{
    public interface IServices
    {
        IBrandService Brand { get; }
        IProductService Product { get; }
        IUserService User { get; }
    }
}