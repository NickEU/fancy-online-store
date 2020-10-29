using Autofac;
using BusinessLayer;
using DAL.Impl.Repos;
using DAL.Interfaces;

namespace DIContainerConfigurator
{
    public class DIConfig
    {
        public static void SetupContainer(string contextType)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MockUserRepoTest>().As<IUserRepo>();
            if (contextType == "test")
            {
                builder.RegisterType<MockUserRepoTest>().As<IUserRepo>();
            } else
            {
                builder.RegisterType<MockUserRepoProd>().As<IUserRepo>();
            }
            builder.RegisterType<UserService>().As<IUserService>();
            var container = builder.Build();
            InitBL.SetContainer(container);
        }
    }
}
