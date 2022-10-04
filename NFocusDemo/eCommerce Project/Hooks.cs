using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NFocusDemo.eCommerce_Project
{
    [Binding]
    internal class Hooks
    {
        private IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Before]
        public void Setup()
        {
            string browser = Environment.GetEnvironmentVariable("BROWSER");

            switch (browser)
            {
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
                case "edge":
                    _driver = new EdgeDriver();
                    break;
                default:
                    Console.WriteLine("No browser or an unkown browser");
                    Console.WriteLine("Using Chrome");
                    _driver = new ChromeDriver();
                    break;
            }
            _driver.Manage().Window.Maximize();
            _scenarioContext["driver"] = _driver;
            _driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";
        }

        [TearDown]
        public void QuitApplication()
        {
            _driver.Quit();
        }


    }
}
