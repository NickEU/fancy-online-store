using System;
using BusinessLayer.Interfaces;

namespace TestSuite
{
    internal class SimpleTest : ITestSuite
    {
        public void RunTestCases(IUserService businessLogic)
        {
            var actual = businessLogic.GetNames();
            Console.WriteLine(string.Join(", ", actual));
            Console.ReadKey();
        }
    }
}
