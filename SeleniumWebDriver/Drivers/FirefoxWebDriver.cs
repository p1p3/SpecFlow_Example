﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using SeleniumWebDriver.Pages;
using SpecFlowHelpers.Drivers;
using SpecFlowHelpers.Pages;

namespace SeleniumWebDriver.Drivers
{
    public class FirefoxWebDriver : IDriver
    {
        public FirefoxWebDriver()
        {
            _turnOnWaitTime = TimeSpan.FromMinutes(4);
        }

        #region Members
        private readonly TimeSpan _turnOnWaitTime;
        private IWebDriver _webDriver;
        private ITePrestaHome _homePage;
        #endregion

        #region Implementation of IDriver

        public void Initialize()
        {
            _webDriver = new FirefoxDriver(new FirefoxBinary(), new FirefoxProfile(), TimeSpan.FromMinutes(4));
            TurnOnWait();
            _homePage = new TePrestaHome(_webDriver);
            _webDriver.Manage().Window.Maximize();
        }


        public void NavigateTo(IPage page)
        {
            _webDriver.Navigate().GoToUrl(page.Address);
        }

        public ITePrestaHome NavigateToHomePage()
        {
            NavigateTo(_homePage);
            return _homePage;
        }

        public void Close()
        {
            _webDriver.Close();
            //Si se corren varias pruebas en paralelo se debe quitar esta línea, ya que cerrará todas las ventanas para ello se debe crear un proceso para liberar memorias
            //Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            //foreach (var chromeDriverProcess in chromeDriverProcesses)
            //{
            //    chromeDriverProcess.Kill();
            //}
            _webDriver.Quit();
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
