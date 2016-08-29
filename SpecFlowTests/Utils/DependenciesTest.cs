using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using SeleniumWebDriver.Drivers;
using SpecFlow.Unity;
using SpecFlowHelpers.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Utils
{
    public static class DependenciesTest
    {
        [ScenarioDependencies]
        public static IUnityContainer GetTestContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IDriver, FirefoxWebDriver>();
            container.RegisterType<ITestDriver, FirefoxTestBase>();

           // container.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();
            return container;
        }
    }
}
