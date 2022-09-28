using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NFocusDemo.PageObjects;

namespace NFocusDemo.Webdrivertests
{
    [TestFixture]
    public class ProductSearch : utils.testbaseclass
    {
        
        [Test, Category("functional")]
        public void SearchItem()
        {
            driver.FindElement(By.CssSelector("#woocommerce-product-search-field-0")).Click();
            driver.FindElement(By.CssSelector("#woocommerce-product-search-field-0")).SendKeys("Cap" + Keys.Enter);
            driver.FindElement(By.CssSelector("#product-29 > div.summary.entry-summary > form > button")).Click();
            driver.FindElement(By.CssSelector("#site-header-cart")).Click();
            driver.FindElement(By.CssSelector("#post-5 > div > div > form > table > tbody > tr.woocommerce-cart-form__cart-item.cart_item > td.product-remove > a")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Verifying that the cart is empty
            driver.FindElement(By.CssSelector("#site-header-cart")).Click();
            //Assert.That(driver.FindElement(By.CssSelector(".cart-empty")).Displayed);

            //driver.FindElement(By.LinkText("Add to cart")).Click();

        }

        [Test]
        public void SanityCheck()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site";

            TopNav topNav = new TopNav(driver);

            topNav.Home.Click();


        }

    }
}
