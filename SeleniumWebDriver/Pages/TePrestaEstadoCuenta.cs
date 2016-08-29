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
    public class TePrestaEstadoCuenta : ITePrestaEstadoCuenta
    {
        private readonly IWebDriver _driver;
        public string Address { get; set; }
        public TePrestaEstadoCuenta(IWebDriver driver)
        {
            _driver = driver;
            Address = string.Concat(Direcciones.BaseAddress, Direcciones.TePrestaRegistroContrasenha);
        }

    }
}
