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
            try
            {
                return _driver.FindElement(By.XPath(".//*[@id='get-started-now']/a")).Text;
            }
            catch (Exception e)
            {
                
                throw e;
            }
           
        }

        #endregion
    }
}
