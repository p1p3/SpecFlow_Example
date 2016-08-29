using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecFlowHelpers;
using SpecFlowHelpers.Pages;

namespace SeleniumWebDriver.Pages
{
    public class TePrestaHome : ITePrestaHome
    {
        private readonly IWebDriver _driver;
        public string Address { get; set; }

        public TePrestaHome(IWebDriver driver)
        {
            _driver = driver;
            Address = Constants.BaseAddress;
        }

        public ITePrestaLogin ClickIngresar()
        {
            var loginButton = _driver.FindElement(By.Id("loginLink"));
            loginButton.Click();
            return new TePrestaLogin(_driver);
        }

    }
}
