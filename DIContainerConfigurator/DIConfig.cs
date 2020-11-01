using Autofac;
using Autofac.Integration.Mvc;
using BusinessLayer;
using BusinessLayer.Implementations;
using DAL.Impl.Repos;
using DAL.Interfaces;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using DAL.Impl.Repos.EF;

namespace DIContainerConfigurator
{
    public class DIConfig
    {
        private static EnvironmentContext Env { get; set; }
        private static readonly ContainerBuilder Builder = new ContainerBuilder();
        public static ContainerBuilder SetupContainer(EnvironmentContext env)
        {
            Env = env;
            if (Env == EnvironmentContext.Test)
            {
                Builder.RegisterType<MockUserRepoTest>().As<IUserRepo>();
            }
            else
            {
                Builder.RegisterType<MockUserRepoProd>().As<IUserRepo>();
            }
            Builder.RegisterType<EFProductRepo>().As<IProductRepo>();
            Builder.RegisterType<UserService>().As<IUserService>();
            Builder.RegisterType<ProductService>().As<IProductService>();
            // not a big fan of exposing this builder, need to find an alternative?
            return Builder;
        }

        public static void FinalizeConfig()
        {
            var container = Builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            InitBL.SetContainer(container);
        }
    }
}
