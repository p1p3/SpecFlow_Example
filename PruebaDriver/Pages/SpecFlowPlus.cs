using OpenQA.Selenium;
using SpecFlowHelpers;
using SpecFlowHelpers.Pages;

namespace PruebaDriver.Pages
{
    public class SpecFlowPlus : ISpecFlowPlus
    {
        private readonly IWebDriver _driver;

        public SpecFlowPlus(IWebDriver driver)
        {
            _driver = driver;
            Address = Constants.SpecFlowPlus;
        }

        #region Implementation of IBasePage

        public string Address { get; set; }
        public ISpecFlowPlusExcel ClickSpecFlowPlusExcel()
        {
            var specFlowPlusExcelButton = _driver.FindElement(By.XPath(".//*[@id='menu-item-698']/a"));
            specFlowPlusExcelButton.Click();
            return  new SpecFlowPlusExcel(_driver);
        }

        #endregion
    }
}
