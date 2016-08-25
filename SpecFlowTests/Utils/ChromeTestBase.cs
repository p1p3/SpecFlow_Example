using System;
using SeleniumWebDriver.Drivers;
using SpecFlowHelpers.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Utils
{


    public class ChromeTestBase
    {

        protected IDriver Driver { get; private set; }

        [BeforeScenario]
        public void Setup()
        {
            var waitTime = TimeSpan.FromSeconds(10000);
            Driver = new FirefoxWebDriver(waitTime);
            Driver.Initialize();
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.Close();
        }


    }

}
