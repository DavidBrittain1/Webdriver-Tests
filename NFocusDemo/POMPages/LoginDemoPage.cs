using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusDemo.POMPages
{
    internal class LoginDemoPage
    {
        IWebDriver driver;

        // Constructor to get driver from test for use in this class
        public LoginDemoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement usernameField => driver.FindElement(By.Id("username"));
        IWebElement passwordField => driver.FindElement(By.Id("password"));
        IWebElement signInButton => driver.FindElement(By.CssSelector("#post-6 > div > div > form.woocommerce-form.woocommerce-form-login.login > p:nth-child(5) > button"));
        IWebElement signInButton2 => driver.FindElement(By.CssSelector("#customer_login > div.u-column1.col-1 > form > p:nth-child(3) > button"));

        public LoginDemoPage setUsername(string username)
        {
            usernameField.Clear();
            usernameField.SendKeys(username);
            return this;
        }

        public LoginDemoPage setPass(string Password)
        {
            passwordField.Clear();
            passwordField.SendKeys(Password);
            return this;
        }

        public void goSubmit()
        {
            signInButton.Click();

        }

        public void loginIntoDemo(string username, string pass)
        {
            setUsername(username);
            setPass(pass);
            goSubmit();
        }

        public void goSubmit2()
        {
            signInButton2.Click();

        }

        public void loginIntoDemo2(string username, string pass)
        {
            setUsername(username);
            setPass(pass);
            goSubmit2();
        }

    }
}
