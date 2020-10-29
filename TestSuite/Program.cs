using System;
using BusinessLayer;
using DIContainerConfigurator;

namespace TestRunner
{
    class Program
    {
        static void Main()
        {
            DIConfig.SetupContainer(EnvironmentContext.TEST);
            DIConfig.FinalizeConfig();
            new SimpleTest().RunTestCases(new UserService());
        }
    }
}
