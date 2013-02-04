using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

using OpenQA.Selenium.Support.PageObjects;

namespace DemoTest.FinalPageObject.Pages
{
    public class MainPage : AbstractPageBase, IHaveExpectedControls
    {

        [FindsBy(Using = @"a[title='Support us']", How = How.CssSelector)]
        public IWebElement lnkDonate;
        

        public void Open()
        {
            Driver.Navigate().GoToUrl(@"http://en.wikipedia.org");
        }

        public void GoToDonatePage()
        {
            lnkDonate.Click();
        }

        public void GoToLoginPage()
        {
            var logInLink = Driver.FindElementByCssSelector(@"a[accessKey='o']");
            logInLink.Click();
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

        public List<IWebElement> GetExpectedControls()
        {
            return new List<IWebElement>() 
            {
                lnkDonate
            };
        }
    }
}
