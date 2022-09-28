using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusDemo.utils
{
    public class testbaseclass
    {
        public IWebDriver driver;

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();

            driver.Url = "https://www.edgewordstraining.co.uk/demo-site";


            Thread.Sleep(3000);

        }

        [TearDown]
        public void teardown()
        {
            Console.WriteLine("Test has been completed");
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
