using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace WebDriverStarterMSTest
{
    public static class MyPages
    {

        public static RemoteWebDriver Driver { get { return WebBrowser.Driver; } }
        public static class MainPage
        {

            public static void Open()
            {
                Driver.Navigate().GoToUrl(@"http://en.wikipedia.org/");
            }

            public static void GoToDonatePage()
            {
                var lnkSupportUs = Driver.FindElementByCssSelector(@"a[title='Support us']");
                lnkSupportUs.Click();
            }
        }

        public static class DonatePage
        {

            public static void Donate_50_UAH_Using_Debit_Card()
            {
                var radio50UAH = Driver.FindElementByCssSelector(@"#input_amount_0[value='50']");
                radio50UAH.Click();


                // And click on "Donate" button
                var btnDonate = Driver.FindElementByCssSelector(@"input[value='Donate by credit/debit card']");
                btnDonate.Click();

            }
        }

    }
}
