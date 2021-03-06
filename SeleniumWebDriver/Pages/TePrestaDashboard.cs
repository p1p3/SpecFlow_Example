﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecFlowHelpers;
using SpecFlowHelpers.Pages;

namespace SeleniumWebDriver.Pages
{
    public class TePrestaDashboard : ITePrestaDashboard
    {

        private readonly IWebDriver _driver;
        public string Address { get; set; }

        public TePrestaDashboard(IWebDriver driver)
        {
            _driver = driver;
            Address = string.Concat(Direcciones.BaseAddress, Direcciones.TePrestaDashboard);
        }

        public string MensajeBienvenida()
        {
            var userName = _driver.FindElement(By.CssSelector(".user-name li"));
            return userName.Text;
        }

    }
}
