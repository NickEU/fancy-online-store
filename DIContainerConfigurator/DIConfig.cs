using Autofac;
using Autofac.Integration.Mvc;
using BusinessLayer;
using DAL.Impl.Repos;
using DAL.Interfaces;
using System.Web.Mvc;

namespace DIContainerConfigurator
{
    public class DIConfig
    {
        private static EnvironmentContext Env { get; set; }
        static readonly ContainerBuilder builder = new ContainerBuilder();
        public static ContainerBuilder SetupContainer(EnvironmentContext _Env)
        {
            Env = _Env;
            if (Env == EnvironmentContext.TEST)
            {
                builder.RegisterType<MockUserRepoTest>().As<IUserRepo>();
            }
            else
            {
                builder.RegisterType<MockUserRepoProd>().As<IUserRepo>();
            }
            builder.RegisterType<UserService>().As<IUserService>();
            // not a big fan of exposing this builder, need to find an alternative?
            return builder;
        }

        public static void FinalizeConfig()
        {
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            InitBL.SetContainer(container);
        }
    }
}
