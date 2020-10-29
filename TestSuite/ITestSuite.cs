using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestRunner
{
    interface ITestSuite
    {
        void RunTestCases(IUserService businessLogic);
    }
}
