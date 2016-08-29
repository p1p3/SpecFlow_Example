using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebDriver.Drivers;
using SpecFlowHelpers;
using SpecFlowHelpers.Database.Definitions;
using SpecFlowHelpers.Pages;
using SpecFlowTests.Utils;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Acceptance_Tests
{
    [Binding]
    public class IngresarAChambaTePrestaSteps
    {
        private readonly ITestDriver _testDriver;
        private readonly ITeprestaFunctions _teprestaFunctions;

        private IChambaHome _homePage;
        private IChambaLogin _chambaLogin;
        private IChambaDashboard _chambaDashboard;

        public IngresarAChambaTePrestaSteps(ITestDriver testDriver, ITeprestaFunctions teprestaFunctions1)
        {
            _testDriver = testDriver;
            _teprestaFunctions = teprestaFunctions1;
        }

        [BeforeScenario]
        public void Setup()
        {
            _teprestaFunctions.DeleteUser(Constants.SignUpUserEmail);
            _testDriver.Start();
        }

        [AfterScenario]
        public void TearDown()
        {
            _testDriver.Stop();
        }

        [Given(@"he ingresado a Chamba te presta")]
        public void DadoHeIngresadoAChambaTePresta()
        {
            _homePage = _testDriver.Driver.NavigateToHomePage();
        }

        [Given(@"he presionado Ingresar")]
        public void DadoHePresionadoIngresar()
        {
            _chambaLogin = _homePage.ClickIngresar();
        }

        [Given(@"he ingresado el correo electrónico")]
        public void DadoHeIngresadoElCorreoElectronico()
        {
            _chambaLogin.SetEmail(Constants.ChambaUser);
        }

        [Given(@"he ingresado mi contraseña")]
        public void DadoHeIngresadoMiContrasena()
        {
            _chambaLogin.SetPassword(Constants.ChambaPassword);
        }

        [When(@"presiono Ingresar")]
        public void CuandoPresionoIngresar()
        {
            _chambaDashboard = _chambaLogin.Ingresar();
        }

        [Then(@"debo ver ""(.*)""")]
        public void EntoncesDeboVer(string p0)
        {
            Assert.AreEqual(p0, _chambaDashboard.MensajeBienvenida());
        }
    }
}
