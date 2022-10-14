using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusDemo.POMPages
{
    internal class ShoppingCartPOM
    {
        IWebDriver driver;

        // Constructor to get driver from test for use in this class
        public ShoppingCartPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement Item => driver.FindElement(By.CssSelector("#main > ul > li.product.type-product.post-28." +
            "status-publish.instock." +
            "product_cat-accessories.has-post-thumbnail.sale." +
            "shipping-taxable.purchasable.product-type-simple > a.button.product_type_simple" +
            ".add_to_cart_button.ajax_add_to_cart"));

        public void AddItem()
        {
            Item.Click();
        }
        
    }
}
