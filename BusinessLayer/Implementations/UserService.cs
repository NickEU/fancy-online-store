using Autofac;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BusinessLayer
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
