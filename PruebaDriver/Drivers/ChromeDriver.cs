using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PruebaDriver.Pages;
using SpecFlowHelpers.Drivers;
using SpecFlowHelpers.Pages;

namespace PruebaDriver.Drivers
{
    public class ChromeWebDriver : IDriver
    {
        public ChromeWebDriver(TimeSpan turnOnWaitTime)
        {
            _webDriver = new ChromeDriver();
            _turnOnWaitTime = turnOnWaitTime;
        }

        #region Members
        private readonly TimeSpan _turnOnWaitTime;
        private IWebDriver _webDriver;
        private ISpecFlowHome _homePage;
        #endregion

        #region Implementation of IDriver

        public void Initialize()
        {
            _webDriver = new ChromeDriver();
            _homePage = new SpecFlowHome(_webDriver);
            TurnOnWait();
            _webDriver.Manage().Window.Maximize();
        }


        public void NavigateTo(IBasePage page)
        {
            _webDriver.Navigate().GoToUrl(page.Address);
        }

        public ISpecFlowHome NavigateToHomePage()
        {
            NavigateTo(_homePage);
            return _homePage;
        }

        public void Close()
        {
            _webDriver.Close();
        }

        public void TurnOnWait()
        {
            _webDriver.Manage().Timeouts().ImplicitlyWait(_turnOnWaitTime);
        }

        public object GetFinalDriver()
        {
            return _webDriver;
        }

        #endregion



    }
}
