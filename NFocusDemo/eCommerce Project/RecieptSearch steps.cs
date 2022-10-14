using NFocusDemo.POMPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NFocusDemo.utils;


namespace NFocusDemo.eCommerce_Project
{
    [Binding]
    internal class StepDefinitions 
    {
        private readonly ScenarioContext _scenarioContext;
        string receiptNumberPaper;
        IWebDriver _driver;
        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            

        }
        public static void TakeAScreenShot(IWebDriver driver, string FileName)
        {
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot file = ssdriver.GetScreenshot();
            file.SaveAsFile(@"C:\Users\DavidBrittain\Documents\Screenshots\" + FileName + ".png", ScreenshotImageFormat.Png);
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            this._driver = (IWebDriver)_scenarioContext["driver"];
            _driver.FindElement(By.LinkText("Dismiss")).Click();
            _driver.FindElement(By.LinkText("Shop")).Click();
            ShoppingCartPOM cart = new ShoppingCartPOM(_driver);
            cart.AddItem();
            helpersinstance myhelper = new helpersinstance(_driver);
            Thread.Sleep(2000);
            myhelper.WaitForElement(2, By.LinkText("View cart"));
            _driver.FindElement(By.CssSelector("a + a[title='View cart']")).Click();
            _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > div > a")).Click();
            Thread.Sleep(2000);
            //IWebElement loginLink = _driver.FindElement(By.CssSelector("#post-6 > div > div > div.woocommerce-form-login-toggle > div > a"));
            //Assert.That(loginLink, Is.Null);
        }

        [Given(@"I have made a purchase")]
        public void GivenIHaveMadeAPurchase()
        {
            
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.CssSelector("#post-6 > div > div > div.woocommerce-form-login-toggle > div > a")).Click();
            Thread.Sleep(2000);
            LoginDemoPage login = new LoginDemoPage(_driver);
            login.loginIntoDemo("abcd@gmail.com", "d");


            _driver.FindElement(By.CssSelector("#billing_first_name")).Clear();
            _driver.FindElement(By.CssSelector("#billing_first_name")).SendKeys("d");
            _driver.FindElement(By.CssSelector("#billing_last_name")).Clear();
            _driver.FindElement(By.CssSelector("#billing_last_name")).SendKeys("d");
            _driver.FindElement(By.CssSelector("#billing_address_1")).Clear();
            _driver.FindElement(By.CssSelector("#billing_address_1")).SendKeys("40 Blue Street");
            _driver.FindElement(By.CssSelector("#billing_city")).Clear();
            _driver.FindElement(By.CssSelector("#billing_city")).SendKeys("London");
            helpersinstance myhelper = new helpersinstance(_driver);
            
            // Short Thread.Sleep used to click the button after the refresh
            myhelper.WaitForElement(7, By.CssSelector("#place_order"));
            Thread.Sleep(500);
            _driver.FindElement(By.CssSelector("#place_order")).Click();

            Thread.Sleep(2000);
            receiptNumberPaper = _driver.FindElement(By.CssSelector("#post-6 > div > div > div > ul > li.woocommerce-order-overview__order.order > strong")).Text;
            TakeAScreenShot(_driver, "Receipt Number");
            Assert.That(_driver.Url.StartsWith("https://www.edgewordstraining.co.uk/demo-site/checkout/order-received"));
        }

        [When(@"I go to my purchase history")]
        public void WhenIGoToMyPurchaseHistory()
        {
            _driver.FindElement(By.CssSelector("#menu-item-46 > a")).Click();
            _driver.FindElement(By.CssSelector("#post-7 > div > div > nav > ul > li.woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--orders")).Click();
        }

        [Then(@"I will find the most recent receipt number")]
        public void ThenIWillFindTheMostRecentReceiptNumber()
        {
            Console.WriteLine(receiptNumberPaper);
            IWebElement receiptTable = _driver.FindElement(By.CssSelector("#post-7 > div > div > div"));
            Assert.That(receiptTable.Text.Contains(receiptNumberPaper), "Receipt number not found");
        }
    }
}

