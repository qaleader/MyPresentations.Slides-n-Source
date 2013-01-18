using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

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

        public static void Close()
        {
            _driver.Dispose();
        }
    }
}
