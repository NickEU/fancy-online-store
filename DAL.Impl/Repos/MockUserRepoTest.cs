using DAL.Interfaces;
using System.Collections.Generic;

namespace DAL.Impl.Repos
{
    public class MockUserRepoTest : IUserRepo
    {
        public IReadOnlyCollection<string> GetNames()
        {
            return new List<string> { "Swift", "Taylor", "Singletary" };
        }
    }
}
