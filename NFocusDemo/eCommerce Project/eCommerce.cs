using NFocusDemo.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NFocusDemo.POMPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNamespace;
using TechTalk.SpecFlow;
using NUnit.Framework.Constraints;
using System.Globalization;

namespace NFocusDemo.eCommerce_Project
{
    internal class eCommerce 
    {

        /// <summary>
        ///  Turn test cases into feature files
        /// </summary>

        [Test, Category("NonBDD Solution")]
        public void Login()
        {       
            // Instantiating Chrome and going to website

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";

            // Setting up PON Demo

            LoginDemoPage loginDemoPage = new LoginDemoPage(driver);

            // Entering the Login details

            //driver.FindElement(By.CssSelector("#username")).SendKeys(Keys.Control + "a");
            //driver.FindElement(By.CssSelector("#username")).SendKeys(Keys.Delete);
            //driver.FindElement(By.CssSelector("#username")).SendKeys("mind");
            //IWebElement password = driver.FindElement(By.CssSelector("#password"));

            // Getting username and password from Runsettings file

            string username = Environment.GetEnvironmentVariable("username");
            string pass = Environment.GetEnvironmentVariable("password");
            
            loginDemoPage.loginIntoDemo2(username, pass);

            // Removing popup and navigating to Shop

            driver.FindElement(By.LinkText("Dismiss")).Click();
            driver.FindElement(By.CssSelector("#menu-item-43 > a")).Click();

            // Adding an item to the cart

            driver.FindElement(By.CssSelector("#main > ul > li.product.type-product.post-28.status-publish.instock.product_cat-accessories.has-post-thumbnail.sale.shipping-taxable.purchasable.product-type-simple > a.button.product_type_simple.add_to_cart_button.ajax_add_to_cart")).Click();

            // Going to the cart

            helpersinstance myhelper = new helpersinstance(driver);
            myhelper.WaitForElement(2, By.LinkText("View cart"));
            driver.FindElement(By.CssSelector("a + a[title='View cart']")).Click();

            // Applying Discount and checking that it works

            // Skipping over this as it remembers the discount when you sign in

            //driver.FindElement(By.CssSelector("#coupon_code")).SendKeys("edgewords" + Keys.Enter);
            //Thread.Sleep(2000);
            //string couponApplied = driver.FindElement(By.CssSelector("Coupon code applied successfully.")).Text;
            //Assert.That(couponApplied, Does.Contain("Coupon code applied successfully."), "Coupon is applied");

            // Asserting that the calculation is correct
            
            /// Use decimal instead of double for calculation


            string initialPricePaper = driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-subtotal > td > span > bdi")).Text;
            var p = initialPricePaper.Remove(0,1);
            //int initialPrice = Convert.ToInt32(initialPricePaper);
            var parseInitialPrice = Convert.ToDecimal(p);
            decimal discount = parseInitialPrice * 0.15m;
            decimal price = parseInitialPrice - discount;
            Thread.Sleep(2000);
            string discountedPrice = driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.order-total > td > strong > span > bdi")).Text;
            Assert.That(discountedPrice, Does.Match(("£" + price).ToString()), "Discount isn't 15%");


            // Quitting application to Log Out

            driver.Quit();
        }

        [Test, Category("NonBDD Solution")]

        public void checkout()
        {
            // Instantiating Chrome and going to website

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";

            // Entering the Login details

            driver.FindElement(By.CssSelector("#username")).Clear();
            driver.FindElement(By.CssSelector("#username")).SendKeys("mind");

            IWebElement password = driver.FindElement(By.CssSelector("#password"));
            string pass = Environment.GetEnvironmentVariable("password");
            password.SendKeys(pass);

            // Removing popup and navigating to Shop

            driver.FindElement(By.LinkText("Dismiss")).Click();
            driver.FindElement(By.CssSelector("#menu-item-43 > a")).Click();

            // Adding an item to the cart

            driver.FindElement(By.CssSelector("#main > ul > li.product.type-product.post-28.status-publish.instock.product_cat-accessories.has-post-thumbnail.sale.shipping-taxable.purchasable.product-type-simple > a.button.product_type_simple.add_to_cart_button.ajax_add_to_cart")).Click();

            // Going to the cart

            helpersinstance myhelper = new helpersinstance(driver);
            //myhelper.WaitForElement(2, By.LinkText("View cart"));
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("a + a[title='View cart']")).Click();

            // Proceeding to the checkout

            myhelper.WaitForElement(2, By.PartialLinkText("Proceed to checkout"));
            driver.FindElement(By.PartialLinkText("Proceed to checkout")).Click();

            // Returning as a customer

            driver.Manage().Window.Maximize();
            driver.FindElement(By.CssSelector("#post-6 > div > div > div.woocommerce-form-login-toggle > div > a")).Click();
            Thread.Sleep(2000);
            LoginDemoPage login = new LoginDemoPage(driver);
            login.loginIntoDemo("abcd@gmail.com", "d");

            // Completing the billing details

            driver.FindElement(By.CssSelector("#billing_first_name")).Clear();
            driver.FindElement(By.CssSelector("#billing_first_name")).SendKeys("d");
            driver.FindElement(By.CssSelector("#billing_last_name")).Clear();
            driver.FindElement(By.CssSelector("#billing_last_name")).SendKeys("d");
            driver.FindElement(By.CssSelector("#billing_address_1")).Clear();
            driver.FindElement(By.CssSelector("#billing_address_1")).SendKeys("40 Blue Street");
            driver.FindElement(By.CssSelector("#billing_city")).Clear();
            driver.FindElement(By.CssSelector("#billing_city")).SendKeys("London");
            //driver.FindElement(By.CssSelector("#billing_phone")).SendKeys("0");
            Thread.Sleep(2000);

            // Clicking on check payments

            driver.FindElement(By.CssSelector("#payment > ul > li.wc_payment_method.payment_method_cheque > label")).Click();

            // Placing the order

            driver.FindElement(By.CssSelector("#place_order")).Click();

            // Taking down the order number from the receipt

            Thread.Sleep(2000);
            string receiptNumberPaper = driver.FindElement(By.CssSelector("#post-6 > div > div > div > ul > li.woocommerce-order-overview__order.order > strong")).Text;
            Console.WriteLine(receiptNumberPaper);

            // Going to my account and checking the order

            driver.FindElement(By.CssSelector("#menu-item-46 > a")).Click();
            driver.FindElement(By.CssSelector("#post-7 > div > div > nav > ul > li.woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--orders")).Click();
            IWebElement receiptTable = driver.FindElement(By.CssSelector("#post-7 > div > div > div"));
            //var receipt = driver.FindElement(By.CssSelector("#post-7 > div > div > div > table > tbody > tr > td.woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number"));
            //var receiptNumber = driver.FindElement(By.CssSelector("#post-7 > div > div > div > table > tbody > tr > td.woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a"));
            Assert.That(receiptTable.Text.Contains(receiptNumberPaper), "Receipt number not found");

        }
    }
}
