using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using SeleniumWebDriver.Drivers;
using SpecFlowHelpers.Drivers;

namespace SpecFlowTests.Utils
{
    public static class DependenciesTest
    {
        public static IUnityContainer GetTestContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IDriver, FirefoxWebDriver>();

            return container;
        }
    }
}
