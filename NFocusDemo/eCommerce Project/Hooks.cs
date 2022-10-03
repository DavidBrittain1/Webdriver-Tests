using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            _driver = new ChromeDriver();
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
