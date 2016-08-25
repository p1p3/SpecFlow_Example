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
    public class ChambaLogin : IChambaLogin
    {
        private readonly IWebDriver _driver;
        public string Address { get; set; }
        public ChambaLogin(IWebDriver driver)
        {
            _driver = driver;
            Address = string.Concat(Constants.BaseAddress, Constants.ChambaLogin);
        }

        public void SetEmail(string email)
        {
            var emailTextBox = _driver.FindElement(By.Id("txtemail"));
            emailTextBox.Clear();
            emailTextBox.SendKeys(email);
        }

        public void SetPassword(string password)
        {
            var passwordTextBox = _driver.FindElement(By.Id("txtpassword"));
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(password);
        }

        public IChambaDashboard Ingresar()
        {
            var loginButton = _driver.FindElement(By.Id("login-password"));
            loginButton.Click();
            return new ChambaDashboard(_driver);
        }
    }
}
