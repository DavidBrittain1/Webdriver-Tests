using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusDemo.POMPages
{
    internal class HomePagePOM
    {

        IWebDriver driver;

        // Constructor to get driver from test for use in this class
        public HomePagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement loginLink => driver.FindElement(By.LinkText("Login To Restricted Area"));

        public void GoLogin()
        {
            loginLink.Click();
        }

    }
}
