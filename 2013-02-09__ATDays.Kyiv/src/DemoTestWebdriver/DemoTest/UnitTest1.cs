using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;


namespace DemoTest
{
    [TestClass]
    public class UnitTest1
    {
        public void Wikipedia+Smart_Search_Test()
        {
            RemoteWebDriver driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("http://en.wikipedia.org/wiki/Main_Page");
            driver.FindElementByCssSelector(@"div#simpleSearch").SendKeys("Webdriver Selenium");
            Assert.AreEqual("http://en.wikipedia.org/wiki/WebDriver#Selenium_WebDriver", driver.Url);
        }


        public void HomeIndex_LogIn_LogOut()
        {
            RemoteWebDriver driver = new InternetExplorerDriver();
            // Navigate to the base url.
            driver.Navigate().GoToUrl("http://localhost:8085/");
            Wait();

            // Delete all cookies on the profile.
            driver.Manage().Cookies.DeleteAllCookies();
            Wait();


            driver.FindElement(By.XPath("//a[text()='Log On']")).Click()
            

            // Click on the Log On link.
            IWebElement logOnLink = driver.FindElement(By.XPath("//a[text()='Log On']"));
            logOnLink.Click();
            Wait();

            // Check that the page title is that of the User/Logon page.
            Assert.That(driver.Title, Is.EqualTo("Task Tracker - Log On"));

            // Enter the username and password.
            IWebElement userName = driver.FindElement(By.Id("UserName"));
            userName.SendKeys("testuser");
            // ... 
        }
    }
}
