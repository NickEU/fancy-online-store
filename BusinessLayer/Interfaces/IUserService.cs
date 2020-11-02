using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        IReadOnlyCollection<string> GetNames();
    }
}
