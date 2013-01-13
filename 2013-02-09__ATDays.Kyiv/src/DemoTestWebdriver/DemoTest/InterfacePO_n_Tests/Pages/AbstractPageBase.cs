using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace DemoTest.InterfacePO_n_Tests.Pages
{
    public abstract class AbstractPageBase
    {
        public  RemoteWebDriver Driver
        {
            get { return WebBrowser.Driver; }
        }
    }
}
