using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace DemoTest.FinalPageObject
{
    public static class WebBrowser
    {
        public static RemoteWebDriver _driver = null;

        public static RemoteWebDriver Driver 
        {
            get
            {
                // _driver = _driver != null ? _driver : new InternetExplorerDriver();
                _driver = _driver ?? new InternetExplorerDriver();
                return _driver;
            }
        }

        public static void WaitUntilVisible(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static void WaitUntilVisible(Func<IWebElement> getElement, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            wait.Until<IWebElement>
            (
                (d) =>
                {
                    try
                    {
                        var element = getElement();
                        if (element.Displayed) return element;
                    }
                    catch (Exception exceptions)
                    {
                        Console.WriteLine(exceptions.Message);
                    }
                    return null;
                }
            );
        }

        public static void Close()
        {
            _driver.Dispose();
        }
    }
}
