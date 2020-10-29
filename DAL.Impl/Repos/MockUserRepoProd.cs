using DAL.Interfaces;
using System.Collections.Generic;

namespace DAL.Impl.Repos
{
    public class MockUserRepoProd : IUserRepo
    {
        public IReadOnlyCollection<string> GetNames()
        {
            return new List<string> { "Smith", "Wilson", "King" };
        }
    }
}
