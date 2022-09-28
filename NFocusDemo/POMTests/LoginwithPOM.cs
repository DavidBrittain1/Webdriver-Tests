using NFocusDemo.POMPages;
using NFocusDemo.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusDemo.POMTests
{
    internal class LoginwithPOM : base_test
    {
        [Test]

        public void LoginTest()
        {
            driver.Url = baseUrl + "/webdriver2";

            HomePagePOM home = new HomePagePOM(driver);
            home.GoLogin();

            LoginPagePOM login = new LoginPagePOM(driver);
            //login.setUsername("edgewords");
            //login.setPass("edgewords123");
            //login.goSubmit();
            //login.LoginWithValidCredentials("edgewords", "edgewords123");
            //login.setUsername("edgewords").setPass("edgewords123").goSubmit();

            bool didWeLogin = login.LoginWithValidCredentials("edgewords", "edgewords123");
            Assert.That(didWeLogin, Is.True, "Wed didn't login");
        }


    }
}
