using System;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace NFocusDemo.utils
{
    internal class base_test
    {
        protected IWebDriver driver;
        protected string baseUrl = "http://www.edgewordstraining.co.uk";

        [SetUp]
        public void Setup()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AcceptInsecureCertificates = true;

            //driver = new ChromeDriver(options);

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //driver = new FirefoxDriver();

            string browser = Environment.GetEnvironmentVariable("BROWSER");

            switch(browser)
            {
                case "firefox":
                        driver = new FirefoxDriver();
                    break;
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    Console.WriteLine("No browser or an unkown browser");
                    Console.WriteLine("Using Chrome");
                    driver = new ChromeDriver();
                    break;
            }
                driver.Manage().Window.Maximize(); 
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            driver.Quit();


        }
    }
}
