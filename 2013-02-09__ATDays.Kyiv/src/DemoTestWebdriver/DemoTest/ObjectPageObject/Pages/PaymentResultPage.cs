using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace DemoTest.ObjectPageObject.Pages
{
    public class PaymentResultPage : AbstractPageBase
    {
        public void WaitUntilExists()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.TitleContains(@"Donate-error - Payments"));
        }

        public string GetResultHeaderText()
        {
            var lblFirstHeader = Driver.FindElementById(@"firstHeading");
            return lblFirstHeader.Text;
        }
    }
}
