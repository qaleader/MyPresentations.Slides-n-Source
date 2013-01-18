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
    public class PaymentResultPage : AbstractPageBase
    {
        [FindsBy(Using = @"firstHeading", How = How.Id)]
        public IWebElement lblFirstHeader;

        
        public void WaitUntilExists()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.TitleContains(@"Donate-error - Payments"));
        }

        public string GetResultHeaderText()
        {
            return lblFirstHeader.Text;
        }
    }
}
