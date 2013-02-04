using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace WebDriverStarterMSTest
{
    public static class WebBrowser
    {
        private static RemoteWebDriver _driver = null;
        public static RemoteWebDriver Driver
        {
            get 
            {
                _driver = _driver ?? new InternetExplorerDriver();
                return _driver;
            }
        }
    }
}
