using System;
using System.Linq;
using Autofac;
using SeleniumWebDriver;
using SeleniumWebDriver.Drivers;
using SpecFlow.Autofac;
using SpecFlowHelpers.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Utils
{
    public static class TestDependencies
    {
        [ScenarioDependencies]
        public static Autofac.ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FirefoxWebDriver>().As<IDriver>();
            builder.RegisterType<FirefoxTestBase>().As<ITestDriver>();

            builder.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();

            return builder;
        }
    }


}
