using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusDemo.PageObjects
{
    internal class TopNav
    {
        IWebDriver driver;
        public TopNav(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Home => driver.FindElement(By.LinkText("Home"));
        public IWebElement Shop => driver.FindElement(By.LinkText("Shop"));
        public IWebElement Cart => driver.FindElement(By.LinkText("Cart"));
        public IWebElement Checkout => driver.FindElement(By.LinkText("Checkout"));
        public IWebElement myAccount => driver.FindElement(By.LinkText("My account"));
        public IWebElement Blog => driver.FindElement(By.LinkText("Blog"));


    }
}
