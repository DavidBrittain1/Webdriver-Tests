using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusDemo.POMPages
{
    internal class LoginPagePOM
    {

        IWebDriver driver;

        // Constructor to get driver from test for use in this class
        public LoginPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement usernameField => driver.FindElement(By.Id("username"));
        IWebElement passwordField => driver.FindElement(By.Id("password"));
        IWebElement submitButton => driver.FindElement(By.LinkText("Submit"));

        public LoginPagePOM setUsername(string username)
        {
            usernameField.Clear();
            usernameField.SendKeys(username);
            return this;
        }

        public LoginPagePOM setPass(string Password)
        {
            passwordField.Clear();
            passwordField.SendKeys(Password);
            return this;
        }

        public void goSubmit()
        {
            submitButton.Click();
            
        }

        public Boolean LoginWithValidCredentials(string username, string password)
        {
            setUsername(username);
            setPass(password);
            goSubmit();

            try
            {
                driver.SwitchTo().Alert();
            }
            catch (Exception)
            {
                return true;
            }
            return false;
        }

        public Boolean LoginWithInvalidCredentials(string username, string password)
        {
            setUsername(username);
            setPass(password);
            goSubmit();

            try
            {
                driver.SwitchTo().Alert();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
