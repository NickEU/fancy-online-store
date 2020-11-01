using BusinessLayer.Interfaces;

namespace TestSuite
{
    interface ITestSuite
    {
        void RunTestCases(IUserService businessLogic);
    }
}
