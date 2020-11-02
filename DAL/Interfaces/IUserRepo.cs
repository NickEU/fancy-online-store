using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUserRepo : IRepository<User>
    {
        IReadOnlyCollection<string> GetNames();
    }
}
