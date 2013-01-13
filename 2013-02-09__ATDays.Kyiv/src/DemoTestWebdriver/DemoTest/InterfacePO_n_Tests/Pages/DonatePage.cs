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
    public class DonatePage : AbstractPageBase, IInvokable
    {
        public void Donate_50_UAH_Using_Debit_Card()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

            var rbtnDonate50 = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(@"input[name='amount'][value='50']")));
            rbtnDonate50.Click();

            var btnMakeDonation = Driver.FindElementByCssSelector(@"input[value='Donate by credit/debit card']");
            btnMakeDonation.Click();

        }

        public void Invoke()
        {
            if (Exists() == false)
            {
                var mainPage = MyPages.MainPage;
                mainPage.Invoke();
                mainPage.GoToDonatePage();
            }
        }

        public bool Exists()
        {
            return Driver.Url == @"https://donate.wikimedia.org/w/index.php?title=Special:FundraiserLandingPage&country=UA&uselang=en&utm_medium=sidebar&utm_source=donate&utm_campaign=C12_en.wikipedia.org";
        }
    }
}
