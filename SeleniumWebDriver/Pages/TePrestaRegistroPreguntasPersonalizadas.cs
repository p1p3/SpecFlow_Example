using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowHelpers;
using SpecFlowHelpers.Pages;

namespace SeleniumWebDriver.Pages
{
    public class TePrestaRegistroPreguntasPersonalizadas: ITePrestaRegistroPreguntasPersonalizadas
    {
        private readonly IWebDriver _driver;
        public string Address { get; set; }
        public TePrestaRegistroPreguntasPersonalizadas(IWebDriver driver)
        {
            _driver = driver;
            Address = string.Concat(Direcciones.BaseAddress, Direcciones.TePrestaRegistroContrasenha);
        }

        #region Implementation of ITePrestaRegistroPreguntasPersonalizadas

        public void ResponderPreguntas(params string[] respuestas)
        {
            var number = 1;
            var usedQuestions = 0;
            foreach (var respuesta in respuestas)
            {
                var xPathDropwdownSelector = ($"(//select[@id='Id'])[{number}]");
                var dropdown = _driver.FindElement(By.XPath(xPathDropwdownSelector));
                var selector = new SelectElement(dropdown);
                selector.SelectByIndex(number);
                number++;

                var cssSelectorAnswer = $"QuestionsPerUser_{usedQuestions}__Answer";
                var answerTextbox =_driver.FindElement(By.Id(cssSelectorAnswer));
                answerTextbox.Clear();
                answerTextbox.SendKeys(respuesta);
                usedQuestions++;
            }
        }

        public ITePrestaDashboard ClickContinuar()
        {
            var valdiateButton = _driver.FindElement(By.Id("validate-questionnaire"));
            valdiateButton.Click();
            return new TePrestaDashboard(_driver);
        }

        #endregion
    }
}
