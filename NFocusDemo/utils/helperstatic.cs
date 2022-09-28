using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusDemo.utils
{
    internal static class helperstatic
    {
        public static void WaitForElementStatic(IWebDriver driver, int Seconds, By locator)
        {
            WebDriverWait myWait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(Seconds));
            myWait2.Until(drv => drv.FindElement(locator).Displayed);
        }

        public static void TakeAScreenShot(IWebDriver driver, string FileName)
        {
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot file = ssdriver.GetScreenshot();
            file.SaveAsFile(@"C:\Users\DavidBrittain\Documents\Screenshots\" + FileName + ".png", ScreenshotImageFormat.Png);
        }

        public static void TakeScreenshotElement(IWebElement element, string FileName)
        {
            ITakesScreenshot sselement = element as ITakesScreenshot;
            Screenshot file = sselement.GetScreenshot();
            file.SaveAsFile(@"C:\Users\DavidBrittain\Documents\Screenshots\" + FileName + ".png", ScreenshotImageFormat.Png);
        }
    }
}
