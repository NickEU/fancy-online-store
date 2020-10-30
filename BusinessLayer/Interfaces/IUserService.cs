using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IUserService
    {
        IReadOnlyCollection<string> GetNames();
    }
}
