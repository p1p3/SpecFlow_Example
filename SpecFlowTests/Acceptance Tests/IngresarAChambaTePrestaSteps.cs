﻿using System;
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

        public IngresarAChambaTePrestaSteps(ITestDriver testDriver, ITeprestaFunctions teprestaFunctions)
        {
            _testDriver = testDriver;
            _teprestaFunctions = teprestaFunctions;
        }

        [BeforeScenario]
        public void Setup()
        {
            _testDriver.Start();
        }

        [AfterScenario]
        public void TearDown()
        {
            _testDriver.Stop();
        }

        [Given(@"he ingresado a te presta")]
        public void DadoHeIngresadoAChambaTePresta()
        {
            var homePage = _testDriver.Driver.NavigateToHomePage();
            ScenarioContext.Current.Set<ITePrestaHome>(homePage);
        }

        [Given(@"he presionado Ingresar")]
        public void DadoHePresionadoIngresar()
        {
            var homePage = ScenarioContext.Current.Get<ITePrestaHome>();
            var tePrestaLogin = homePage.ClickIngresar();
            ScenarioContext.Current.Set<ITePrestaLogin>(tePrestaLogin);
        }

        [Given(@"he ingresado el correo electrónico")]
        public void DadoHeIngresadoElCorreoElectronico()
        {
            var tePrestaLogin = ScenarioContext.Current.Get<ITePrestaLogin>();
            tePrestaLogin.SetEmail(Constants.SignInUser);
        }

        [Given(@"he ingresado mi contraseña")]
        public void DadoHeIngresadoMiContrasena()
        {
            var tePrestaLogin = ScenarioContext.Current.Get<ITePrestaLogin>();
            tePrestaLogin.SetPassword(Constants.SignInPassword);
        }

        [When(@"presiono Ingresar")]
        public void CuandoPresionoIngresar()
        {
            var tePrestaLogin = ScenarioContext.Current.Get<ITePrestaLogin>();
            var tePrestaDashboard = tePrestaLogin.Ingresar();
            ScenarioContext.Current.Set<ITePrestaDashboard>(tePrestaDashboard);
        }

        [Then(@"debo ver un mensaje de bienvenida")]
        public void EntoncesDeboVerUnMensajeDeBienvenida()
        {
            var tePrestaDashBoard = ScenarioContext.Current.Get<ITePrestaDashboard>();
            var msgBienvenida = tePrestaDashBoard.MensajeBienvenida();
            var mensajeCorrecto = msgBienvenida.Contains(Constants.WelcomeMessage);
            Assert.IsTrue(mensajeCorrecto);
        }

    }
}
