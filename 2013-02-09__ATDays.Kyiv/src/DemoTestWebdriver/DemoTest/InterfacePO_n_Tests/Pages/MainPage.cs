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
    public class MainPage : AbstractPageBase, IInvokable
    {
        public void Open()
        {
            Driver.Navigate().GoToUrl(@"http://en.wikipedia.org");
        }

        public void GoToDonatePage()
        {
            var lnkDonate = Driver.FindElementByCssSelector(@"a[title='Support us']");
            lnkDonate.Click();
        }

        public void Invoke()
        {
            if (Exists() == false)
            {
                Open();
            }
        }

        public bool Exists()
        {
            return Driver.Url == @"http://en.wikipedia.org/wiki/Main_Page";
        }
    }
}
