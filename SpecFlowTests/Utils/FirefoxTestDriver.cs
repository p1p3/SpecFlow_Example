using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebDriver.Drivers;
using SpecFlowHelpers.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Utils
{


    public class FirefoxTestBase : ITestDriver
    {

        public FirefoxTestBase(IDriver driver)
        {
            Driver = driver;
        }

        public IDriver Driver { get; private set; }

        public void Start()
        {
            Driver.Initialize();
        }

        public void Stop()
        {
            Driver.Close();
        }

        [AfterStep]
        public void Check()
        {
            var exception = ScenarioContext.Current.TestError;
        }


    }

}
