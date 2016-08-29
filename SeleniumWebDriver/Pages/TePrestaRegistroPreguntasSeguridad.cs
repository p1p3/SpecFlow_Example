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
    public class TePrestaRegistroPreguntasSeguridad: ITePrestaRegistroPreguntasSeguridad
    {
        private readonly IWebDriver _driver;
        public string Address { get; set; }
        public TePrestaRegistroPreguntasSeguridad(IWebDriver driver)
        {
            _driver = driver;
            Address = string.Concat(Direcciones.BaseAddress, Direcciones.TePrestaRegistroPreguntasSeguridad);
        }

        #region Implementation of ITePrestaRegistroPreguntasSeguridad

        public void ResponderPreguntas(params int[] respuestas)
        {
            /* driver.FindElement(By.Id("Answers_0__Answer")).Click();
            driver.FindElement(By.Id("Answers_1__Answer")).Click();
            driver.FindElement(By.Id("Answers_2__Answer")).Click();
            driver.FindElement(By.Id("Answers_3__Answer")).Click();
            driver.FindElement(By.Id("validate-questionnaire")).Click();*/
        }

        public ITePrestaRegistroSolicitarContrasenha ClickValidar()
        {
            var valdiateButton = _driver.FindElement(By.Id("validate-questionnaire"));
            valdiateButton.Click();
            return new TePrestaRegistroSolicitarContrasenha(_driver);
        }

        #endregion
    }
}
