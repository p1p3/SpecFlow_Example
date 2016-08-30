using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowHelpers.Database.Definitions;
using SpecFlowHelpers.Pages;
using SpecFlowTests.Utils;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Acceptance_Tests
{
    [Binding]
    public class CommonSteps
    {
        [Given(@"he ingresado a te presta")]
        public void DadoHeIngresadoAChambaTePresta()
        {
            var testDriver = ScenarioContext.Current.Get<ITestDriver>();
            var homePage = testDriver.Driver.NavigateToHomePage();
            ScenarioContext.Current.Set<ITePrestaHome>(homePage);
        }
    }
}
