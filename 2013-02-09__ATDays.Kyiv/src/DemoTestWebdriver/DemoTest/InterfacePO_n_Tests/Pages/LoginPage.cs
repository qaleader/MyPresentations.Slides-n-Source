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
    public class LoginPage : AbstractPageBase, IInvokable
    {

        public void Invoke()
        {
            if (this.Exists() == false)
            {
                var mainPage = MyPages.MainPage;
                mainPage.Invoke();
                mainPage.GoToLoginPage();
            }
        }

        public bool Exists()
        {
            return Driver.Title == @"Log in / create account - Wikipedia, the free encyclopedia";
        }
    }
}
