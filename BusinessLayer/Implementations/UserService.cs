using System.Collections.Generic;
using Autofac;
using BusinessLayer.Interfaces;
using DAL.Interfaces;

namespace BusinessLayer.Implementations
{
    public class UserService : IUserService
    {
        public IReadOnlyCollection<string> GetNames()
        {
            var container = InitBL.Container;
            using (var scope = container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IUserRepo>();
                return repo.GetNames();
            }
        }
    }
}
