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
    public class ChambaHome : IChambaHome
    {
        private readonly IWebDriver _driver;
        public string Address { get; set; }

        public ChambaHome(IWebDriver driver)
        {
            _driver = driver;
            Address = Constants.BaseAddress;
        }

        public IChambaLogin ClickIngresar()
        {
            var loginButton = _driver.FindElement(By.Id("loginLink"));
            loginButton.Click();
            return new ChambaLogin(_driver);
        }

    }
}
