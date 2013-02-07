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
    public class LoginPage : AbstractPageBase, IHaveExpectedControls
    {

        [FindsBy(How = How.Name, Using = "wpName Похулиганим")]
        private IWebElement txtUserName;

        [FindsBy(How = How.Name, Using = "wpPassword")]
        private IWebElement txtPassword;

        [FindsBy(How = How.Name, Using = "wpLoginAttempt")]
        private IWebElement btnLogin;
        
        public void Invoke()
        {
            if (this.Exists() == false)
            {
                var mainPage = MyPages.MainPage;
                mainPage.Invoke();
                mainPage.GoToLoginPage();
                WebBrowser.WaitUntilVisible(
                    () => btnLogin, 10
                );
            }

        }

        public bool Exists()
        {
            return Driver.Title == @"Log in / create account - Wikipedia, the free encyclopedia";
        }


        public List<IWebElement> GetExpectedControls()
        {
            return new List<IWebElement>()
            {
                txtUserName,
                txtPassword,
                btnLogin,
            };
        }
    }
}
