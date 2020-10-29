using BusinessLayer;
using System;

namespace TestRunner
{
    class SimpleTest : ITestSuite
    {
        public void RunTestCases(IUserService businessLogic)
        {
            var actual = businessLogic.GetNames();
            Console.WriteLine(string.Join(", ", actual));
            Console.ReadKey();
        }
    }
}
