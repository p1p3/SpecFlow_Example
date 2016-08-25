using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowHelpers;
using SpecFlowHelpers.Drivers;
using SpecFlowHelpers.Pages;

namespace SeleniumWebDriver.Pages
{
    public class SpecFlowHome : ISpecFlowHome
    {
        private readonly IWebDriver _driver;

        public SpecFlowHome(IWebDriver driver)
        {
            _driver = driver;
            Address = Constants.BaseAddress;
        }

        #region Implementation of IBasePage

        public string Address { get; set; }
        public ISpecFlowPlus ClickSpecFlowPlus()
        {
            var action = new Actions(_driver);
            var specFlowPlusButton = _driver.FindElement(By.XPath(".//*[@id='menu-item-701']/a"));
            action.MoveToElement(specFlowPlusButton).Perform();
            return  new SpecFlowPlus(_driver);
        }

        #endregion
    }
}
