using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusDemo.utils
{
    internal class helpersinstance
    {
        IWebDriver driver;

        public helpersinstance(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Helper Method
        public void WaitForElement(int Seconds, By locator)
        {
            WebDriverWait myWait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(Seconds));
            myWait2.Until(drv => drv.FindElement(locator).Displayed);
        }
    }
}
