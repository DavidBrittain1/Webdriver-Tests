using NFocusDemo.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using static System.Net.WebRequestMethods;

namespace MyNamespace
{
    [Binding]
    public class Discount_Steps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public Discount_Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            _driver.FindElement(By.LinkText("Dismiss")).Click();
            _driver.FindElement(By.CssSelector("#menu-item-43 > a")).Click();
            _driver.FindElement(By.CssSelector("#main > ul > li.product.type-product.post-28.status-publish.instock.product_cat-accessories.has-post-thumbnail.sale.shipping-taxable.purchasable.product-type-simple > a.button.product_type_simple.add_to_cart_button.ajax_add_to_cart")).Click();
            helpersinstance myhelper = new helpersinstance(_driver);
            myhelper.WaitForElement(2, By.LinkText("View cart"));
            _driver.FindElement(By.CssSelector("a + a[title='View cart']")).Click();
            _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > div > a")).Click();
            Thread.Sleep(2000);
            //IWebElement loginLink = _driver.FindElement(By.CssSelector("#post-6 > div > div > div.woocommerce-form-login-toggle > div > a"));
            //Assert.That(loginLink, Is.Null);
        }

        [Given(@"I am at the checkout")]
        public void GivenIAmAtTheCheckout()
        {
           Assert.That(_driver.Url.Equals("https://www.edgewordstraining.co.uk/demo-site/checkout/"));
        }

        [When(@"I enter in the discount code")]
        public void WhenIEnterInTheDiscountCode()
        {
            //_driver.FindElement(By.CssSelector("#post-6 > div > div > div.woocommerce-form-coupon-toggle > div > a")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.CssSelector("#post-6 > div > div > div.woocommerce-form-coupon-toggle > div > a")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.CssSelector("#coupon_code")).SendKeys("Edgewords");
        }

        [Then(@"(.*)% discount will be applied to the total price")]
        public void ThenDiscountWillBeAppliedToTheTotalPrice(int p0)
        {
            // Applying Discount
            _driver.FindElement(By.CssSelector("#post-6 > div > div > form.checkout_coupon.woocommerce-form-coupon > p.form-row.form-row-last > button")).Click();

            // Checking the Discount is 15%
            string total = _driver.FindElement(By.CssSelector("#order_review > table > tfoot > tr.order-total > td")).Text;
            IWebElement subTotal = _driver.FindElement(By.CssSelector("#order_review > table > tbody > tr > td.product-total"));
            var subTotalString = subTotal.ToString();
            string sTotalString = subTotalString.Remove(0, 1);
            double newSubTotal = Convert.ToDouble(sTotalString);
            double discount = newSubTotal * 0.15;

            double priceAfterDiscount = newSubTotal - discount;
            string compareAfterDiscount = priceAfterDiscount.ToString();
            Assert.That(total, Does.Match(compareAfterDiscount));
        }
    }
}
