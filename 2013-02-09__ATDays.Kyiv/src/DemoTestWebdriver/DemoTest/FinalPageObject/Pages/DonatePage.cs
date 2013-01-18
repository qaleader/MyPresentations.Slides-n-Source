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
    public class DonatePage : AbstractPageBase, IHaveExpectedControls
    {

        [FindsBy(Using=@"input[name='amount'][value='50']", How = How.CssSelector)]
        public IWebElement rbtnDonate50;

        [FindsBy(Using=@"input[value='Donate by credit/debit card']", How = How.CssSelector)]
        public IWebElement btnMakeDonation;

        
        public void Donate_50_UAH_Using_Debit_Card()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            
            wait.Until<IWebElement>( e => rbtnDonate50.Displayed ? rbtnDonate50 : null);
            rbtnDonate50.Click();
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

        public List<IWebElement> GetExpectedControls()
        {
            return new List<IWebElement>()
            {
                rbtnDonate50,
                btnMakeDonation
            };

        }
    }
}
