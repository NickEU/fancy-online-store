using BusinessLayer.Implementations;
using DIContainerConfigurator;

namespace TestSuite
{
    internal class Program
    {
        private static void Main()
        {
            DIConfig.SetupContainer(EnvironmentContext.Test);
            DIConfig.FinalizeConfig();
            new SimpleTest().RunTestCases(new UserService());
        }
    }
}
