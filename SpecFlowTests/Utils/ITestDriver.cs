using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWebDriver.Drivers;
using SpecFlowHelpers.Drivers;

namespace SpecFlowTests.Utils
{
    public interface ITestDriver
    {
        IDriver Driver { get; }

        void Start();

        void Stop();

    }
}
