using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowHelpers;
using SpecFlowHelpers.Pages;
using SpecFlowTests.Utils;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Acceptance_Tests
{
    [Binding]
    public class NavigateSpecFlowExcelSteps : ChromeTestBase
    {
        private ISpecFlowHome _homePage;
        private ISpecFlowPlus _specFlowPlus;
        private ISpecFlowPlusExcel _specFlowPlusExcel;


        [Given(@"the specflow page")]
        public void GivenTheSpecflowPage()
        {
            _homePage = base.Driver.NavigateToHomePage();
        }

        [When(@"I press Specflow\+")]
        public void WhenIPressSpecflow()
        {
            _specFlowPlus = _homePage.ClickSpecFlowPlus();
        }

        [When(@"Specflow\+-Excel")]
        public void WhenSpecflow_Excel()
        {
            _specFlowPlusExcel = _specFlowPlus.ClickSpecFlowPlusExcel();
        }

        [Then(@"I'(.*)'Get Started Now with Specflow\+ Excel!' button")]
        public void ThenIGetStartedNowWithSpecflowExcelButton(string p0)
        {
            Assert.AreEqual(Constants.StartedExcelButtonText, _specFlowPlusExcel.GetButtonsGetStartedText());
        }


    }
}
