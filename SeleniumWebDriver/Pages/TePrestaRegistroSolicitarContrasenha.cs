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
    public class TePrestaRegistroSolicitarContrasenha : ITePrestaRegistroSolicitarContrasenha
    {
        private readonly IWebDriver _driver;
        public string Address { get; set; }
        public TePrestaRegistroSolicitarContrasenha(IWebDriver driver)
        {
            _driver = driver;
            Address = string.Concat(Direcciones.BaseAddress, Direcciones.TePrestaRegistroContrasenha);
        }

        #region Implementation of ITePrestaRegistroSolicitarContrasenha

        public void IngresarContrasenha(string password)
        {
            var passwordTextBox = _driver.FindElement(By.Id("Password"));
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(password);
        }

        public void IngresarConfirmacionContrasena(string password)
        {
            var confirmPasswordTextBox = _driver.FindElement(By.Id("Password"));
            confirmPasswordTextBox.Clear();
            confirmPasswordTextBox.SendKeys(password);
        }

        public ITePrestaRegistroPreguntasPersonalizadas ClickSiguiente()
        {
            var siguienteButton = _driver.FindElement(By.Id("register-password"));
            siguienteButton.Click();
            return new TePrestaRegistroPreguntasPersonalizadas(_driver);
        }

        #endregion
    }
}
