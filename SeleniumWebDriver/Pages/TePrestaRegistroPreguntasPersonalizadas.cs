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
            /*new SelectElement(driver.FindElement(By.Id("Id"))).SelectByText("Cual es tu cantante/banda favorito?");
            driver.FindElement(By.Id("QuestionsPerUser_0__Answer")).Clear();
            driver.FindElement(By.Id("QuestionsPerUser_0__Answer")).SendKeys("hola");
            new SelectElement(driver.FindElement(By.XPath("(//select[@id='Id'])[2]"))).SelectByText("Cual es tu bebida favorita?");
            driver.FindElement(By.Id("QuestionsPerUser_1__Answer")).Clear();
            driver.FindElement(By.Id("QuestionsPerUser_1__Answer")).SendKeys("hola");
            new SelectElement(driver.FindElement(By.XPath("(//select[@id='Id'])[3]"))).SelectByText("Cual es el actor o superhéroe favorito?");
            driver.FindElement(By.Id("QuestionsPerUser_2__Answer")).Clear();
            driver.FindElement(By.Id("QuestionsPerUser_2__Answer")).SendKeys("hola");
            new SelectElement(driver.FindElement(By.XPath("(//select[@id='Id'])[4]"))).SelectByText("Cual es el nombre de tu mascota?");
            driver.FindElement(By.Id("QuestionsPerUser_3__Answer")).Clear();
            driver.FindElement(By.Id("QuestionsPerUser_3__Answer")).SendKeys("hola");
            new SelectElement(driver.FindElement(By.XPath("(//select[@id='Id'])[5]"))).SelectByText("Cual es la marca de tu primer carro?");
            driver.FindElement(By.Id("QuestionsPerUser_4__Answer")).Clear();
            driver.FindElement(By.Id("QuestionsPerUser_4__Answer")).SendKeys("hola");
            driver.FindElement(By.Id("validate-questionnaire")).Click();*/
        }

        public ITePrestaEstadoCuenta ClickValidar()
        {
            var valdiateButton = _driver.FindElement(By.Id("validate-questionnaire"));
            valdiateButton.Click();
            return new TePrestaEstadoCuenta(_driver);
        }

        #endregion
    }
}
