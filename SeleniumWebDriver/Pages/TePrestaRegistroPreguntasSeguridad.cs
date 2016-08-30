using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            var number = 0;
            foreach (var respuesta in respuestas)
            {
                var cssFormat = ($"[name = 'Answers[{number}].Answer']");
                var radioButton = _driver.FindElements(By.CssSelector(cssFormat))[respuesta];
                Thread.Sleep(500);
                radioButton.Click();
                number++;
            }
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
