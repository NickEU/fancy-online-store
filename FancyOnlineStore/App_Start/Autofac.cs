using Autofac.Integration.Mvc;
using DIContainerConfigurator;

namespace FancyOnlineStore
{
    public class Autofac
    {
        public static void Initialize()
        {
            var builder = DIConfig.SetupContainer(EnvironmentContext.Production);
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            DIConfig.FinalizeConfig();
        }
    }
}