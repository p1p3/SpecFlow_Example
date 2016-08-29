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
    public class TePrestaRegistroVerificacionCelular: ITePrestaRegistroVerificacionCelular
    {
        private readonly IWebDriver _driver;
        public string Address { get; set; }
        public TePrestaRegistroVerificacionCelular(IWebDriver driver)
        {
            _driver = driver;
            Address = string.Concat(Direcciones.BaseAddress, Direcciones.TePrestaRegistroVerificacionCelular);
        }

        #region Implementation of ITePrestaRegistroVerificacionCelular

        public void IngresarDocumentoIdentidad(string documento)
        {
            var identificactionTextBox = _driver.FindElement(By.Id("IdentificationNumber"));
            identificactionTextBox.Clear();
            identificactionTextBox.SendKeys(documento);
        }

        public void IngresarConfirmacionDocumento(string documento)
        {
            var confirmIdentificationNumberTextBox = _driver.FindElement(By.Id("ConfirmIdentificationNumber"));
            confirmIdentificationNumberTextBox.Clear();
            confirmIdentificationNumberTextBox.SendKeys(documento);
        }

        public void IngresoNumeroCelular(string celular)
        {
            var cellphoneNumberTextBox = _driver.FindElement(By.Id("Cellphone"));
            cellphoneNumberTextBox.Clear();
            cellphoneNumberTextBox.SendKeys(celular);
        }

        public void ClickEnviarCodigoVerificacion()
        {
            var sendCodeButton = _driver.FindElement(By.Id("send-verification-code"));
            sendCodeButton.Click();
        }

        public void IngresarCodigoVerificacion(string codigo)
        {
            var confirmNumberTextBox = _driver.FindElement(By.Id("Code"));
            confirmNumberTextBox.Clear();
            confirmNumberTextBox.SendKeys(codigo);
        }

        public void ClickVerificar()
        {
            var confirmCodeButton = _driver.FindElement(By.Id("validate-verification-code"));
            confirmCodeButton.Click();
        }

        public void IngresarCorreoElectronico(string email)
        {
            var emailTextBox = _driver.FindElement(By.Id("Email"));
            emailTextBox.Clear();
            emailTextBox.SendKeys(email);
        }

        public ITePrestaRegistroPreguntasSeguridad ClickContinuar()
        {
            var continueButton = _driver.FindElement(By.Id("continue-button"));
            continueButton.Click();
            return new TePrestaRegistroPreguntasSeguridad(_driver);
        }

        #endregion
    }
}
