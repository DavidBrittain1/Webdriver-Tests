using NFocusDemo.eCommerce_Project;
using NFocusDemo.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using static System.Net.WebRequestMethods;

namespace MyNamespace
{
    [Binding]
    internal class Discount_Steps 
    {
        private readonly ScenarioContext _scenarioContext;
        IWebDriver _driver;
        public Discount_Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

  

        [Given(@"I am at the checkout")]
        public void GivenIAmAtTheCheckout()
        {
            this._driver = (IWebDriver)_scenarioContext["driver"];
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
        public void ThenDiscountWillBeAppliedToTheTotalPrice(string p0)
        {
            // Applying Discount
            _driver.FindElement(By.CssSelector("#post-6 > div > div > form.checkout_coupon.woocommerce-form-coupon > p.form-row.form-row-last > button")).Click();
            p0 = "0.15";
            decimal discountNumber = Convert.ToDecimal(p0);
            // Checking the Discount is 15%
            Thread.Sleep(2000);
            string total = _driver.FindElement(By.CssSelector("#order_review > table > tfoot > tr.order-total > td > strong > span > bdi")).Text;
            IWebElement subTotal = _driver.FindElement(By.CssSelector("#order_review > table > tfoot > tr.cart-subtotal > td > span > bdi"));
            var subTotalString = subTotal.Text;
            string sTotalString = subTotalString.Remove(0, 1);
            decimal newSubTotal = Convert.ToDecimal(sTotalString);
            decimal discount = newSubTotal * discountNumber;
            decimal priceAfterDiscount = newSubTotal - discount;

            /// Adding shipping cost 
            string shippingCost = _driver.FindElement(By.CssSelector("#shipping_method > li > label > span > bdi")).Text;
            string sShippingCost = shippingCost.Remove(0, 1);
            decimal shippingCostNumber = Convert.ToDecimal(sShippingCost);

            decimal priceAfterShipping = priceAfterDiscount + shippingCostNumber;
            string totalPrice = priceAfterShipping.ToString();

            /// Trimming the extra decimal places for a happy comparison
            string suitablePriceComparison = totalPrice.Remove(5, 2);
            Console.WriteLine(suitablePriceComparison);
            Console.WriteLine(total);
            Assert.That(total, Does.Match("£" + suitablePriceComparison));
        }
    }
}
