using System;
using SeleniumWebDriver.Drivers;
using SpecFlowHelpers.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Utils
{

 
    public class FirefoxTestBase
    {

        protected IDriver Driver { get; private set; }

        public void Start()
        {
            var waitTime = TimeSpan.FromSeconds(10000);
            Driver = new FirefoxWebDriver(waitTime);
            Driver.Initialize();
        }

        public void Stop()
        {
            Driver.Close();
        }


    }

}
