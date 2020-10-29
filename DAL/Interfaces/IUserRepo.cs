using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IUserRepo : IRepository
    {
        IReadOnlyCollection<string> GetNames();
    }
}
