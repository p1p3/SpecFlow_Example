using OpenQA.Selenium;
using SpecFlowHelpers;
using SpecFlowHelpers.Pages;

namespace PruebaDriver.Pages
{
    public class SpecFlowPlusExcel : ISpecFlowPlusExcel
    {
        private readonly IWebDriver _driver;

        public SpecFlowPlusExcel(IWebDriver driver)
        {
            _driver = driver;
            Address = Constants.SpecFlowPlusExcel;
        }

        #region Implementation of IBasePage

        public string Address { get; set; }
        public string GetButtonsGetStartedText()
        {
            return _driver.FindElement(By.XPath(".//*[@id='get-started-now']/a")).Text;
        }

        #endregion
    }
}
