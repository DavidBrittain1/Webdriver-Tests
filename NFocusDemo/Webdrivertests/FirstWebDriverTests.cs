using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFocusDemo.utils;
using static NFocusDemo.utils.helperstatic;


namespace NFocusDemo.Webdrivertests
{
    internal class FirstWebDriverTests : base_test
    {
    

        [Test, Category("Run")]
        public void Test1()
        {
            Console.WriteLine("Starting test");
            driver.Url = baseUrl + "/webdriver2";
            Console.WriteLine("Navigate to login page");
            driver.FindElement(By.LinkText("Login To Restricted Area")).Click();
            //driver.FindElement(By.CssSelector("#username")).Clear();

            helpersinstance myhelper = new helpersinstance(driver);
            myhelper.WaitForElement(2, By.LinkText("Login"));

            Console.WriteLine("Entering login details");
            driver.FindElement(By.CssSelector("#username")).SendKeys(Keys.Control + "a");
            driver.FindElement(By.CssSelector("#username")).SendKeys(Keys.Delete);
            driver.FindElement(By.CssSelector("#username")).SendKeys("mind" + Keys.Enter);
            
            driver.FindElement(By.CssSelector("#username")).Clear();
            driver.FindElement(By.CssSelector("#username")).SendKeys("edgewords");
            IWebElement password = driver.FindElement(By.CssSelector("#password"));
            string secret_password = Environment.GetEnvironmentVariable("password");

            password.SendKeys(secret_password);

            // Take a screenshot using static helper
            TakeAScreenShot(driver, "page");
            IWebElement form = driver.FindElement(By.Id("right-column"));
            TakeScreenshotElement(form, "aform");
            TestContext.AddTestAttachment(@"C:\Users\DavidBrittain\Documents\Screenshots\aform.png");

            //Capturing text
            string headingtext = driver.FindElement(By.CssSelector("#right-column > h1")).Text;
            Console.WriteLine("The heading is " + headingtext);

            string pageTitle = driver.Title;
            Console.WriteLine("Page title is " + pageTitle);

            string typedUsername = driver.FindElement(By.CssSelector("#username")).GetAttribute("value");
            Console.WriteLine("Typed username was " + typedUsername);
            driver.FindElement(By.LinkText("Submit")).Click();
            Console.WriteLine("this wasn't here initially");

            WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            myWait.Until(drv => drv.FindElement(By.LinkText("Log Out")).Displayed);

            driver.FindElement(By.LinkText("Log Out")).Click();
            driver.SwitchTo().Alert().Accept();

            WaitForElementStatic(driver, 5, By.LinkText("Login"));

            string loggedintext = driver.FindElement(By.CssSelector("body")).Text;
            Console.WriteLine("Captured text is " + loggedintext);

            Assert.That(loggedintext, Does.Contain("User is not Logged in"), "We must still be logged in");

            string curr = "15.25";
            Decimal safecurr = Decimal.Parse(curr);

        }





        [Test, Ignore("Don't need to run this")]
        public void DragDrop()
        {
            driver.Url = baseUrl + "/webdriver2/docs/cssXPath.html";

            IWebElement gripper = driver.FindElement(By.CssSelector("#slider > a"));

            Actions myAction = new Actions(driver);

            IAction dragdrop = myAction.ClickAndHold(gripper)
                .MoveByOffset(10, 0)
                .MoveByOffset(10, 0)
                .MoveByOffset(10, 0)
                .MoveByOffset(10, 0)
                .MoveByOffset(10, 0)
                .MoveByOffset(10, 0)
                .MoveByOffset(10, 0)
                .MoveByOffset(10, 0)
                .Release()
                .Build();

            dragdrop.Perform();

        }

        [Test]
        public void textareacapture()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/webdriver2/docs/forms.html";

            driver.FindElement(By.CssSelector("#textArea")).SendKeys("Hello");
        }

    }
}
