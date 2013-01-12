using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace DemoTest
{
    [TestClass]
    public class UnitTest1
    {
        public void Wikipedia_Smart_Search_Test()
        {
            RemoteWebDriver driver = new InternetExplorerDriver();
            driver.Navigate()
                  .GoToUrl("http://en.wikipedia.org/wiki/Main_Page");
            driver.FindElementByCssSelector(@"div#simpleSearch")
                  .SendKeys("Webdriver Selenium");
            Assert.AreEqual("http://en.wikipedia.org/wiki/WebDriver#Selenium_WebDriver"
                           , driver.Url);
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


            driver.FindElement(By.XPath("//a[text()='Log On']")).Click();
            

            // Click on the Log On link.
            IWebElement logOnLink = driver.FindElement(By.XPath("//a[text()='Log On']"));
            logOnLink.Click();
            Wait();

            // Check that the page title is that of the User/Logon page.
            Assert.AreEqual(driver.Title, "Task Tracker - Log On");

            // Enter the username and password.
            IWebElement userName = driver.FindElement(By.Id("UserName"));
            userName.SendKeys("testuser");
            // ... 
        }

        private void Wait()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Donate_test()
        {
            RemoteWebDriver driver = new InternetExplorerDriver();
            // Navigate to the base url.
            driver.Navigate().GoToUrl(@"http://en.wikipedia.org");

            // Main Page
            var lnkDonate = driver.FindElementByCssSelector(@"a[title='Support us']");
            lnkDonate.Click();

            // Donate Page
            var rbtnDonate50 = driver.FindElementByCssSelector(@"input[name='amount'][value='50']");
            rbtnDonate50.Click();

            var btnMakeDonation = driver.FindElementByCssSelector(@"input[value='Donate by credit/debit card']");
            btnMakeDonation.Click();

            // Donation Payments
            var txtFirstName = driver.FindElementByName("fname");
            var txtLastName = driver.FindElementByName("lname");
            var txtStreet = driver.FindElementByName("street");
            var txtPostalCode = driver.FindElementByName("zip");
            var txtCity = driver.FindElementByName("city");
            var txtEmailAddress = driver.FindElementByName("emailAdd");
            var rbtnCardVisa = driver.FindElementByCssSelector(@"input[name='cardtype'][value='visa']");


            txtFirstName.Clear();
            txtFirstName.SendKeys("Vasya");

            txtLastName.Clear();
            txtLastName.SendKeys("Pupkin");

            txtStreet.Clear();
            txtStreet.SendKeys("Blah blah blah street");

            txtPostalCode.Clear();
            txtPostalCode.SendKeys("8577");

            txtCity.Clear();
            txtCity.SendKeys("My Str");

            txtEmailAddress.Clear();
            txtEmailAddress.SendKeys("valid@example.com");

            rbtnCardVisa.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            
            var frameCardNumber=wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(@"iframe[src^='https://na.gcsip.com/orb/']")));

            driver.SwitchTo().Frame(frameCardNumber);

            var txtName = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("CREDITCARDNUMBER")));

            txtName.Clear();
            txtName.SendKeys("4556767453966453");

            var ddlMonthSelect = new SelectElement(driver.FindElementByName(@"EXPIRYDATE_MM"));
            var ddlYearSelect = new SelectElement(driver.FindElementByName(@"EXPIRYDATE_YY"));
            var txtSecurityCode = driver.FindElementByName(@"CVV");
            var btnContinue = driver.FindElementById("btnSubmit");

            ddlMonthSelect.SelectByText("05");
            ddlYearSelect.SelectByText("15");
            txtSecurityCode.SendKeys("555");

            Assert.IsTrue(btnContinue.Displayed, "There is a Continue button");
            
            btnContinue.SendKeys(Keys.Enter);

            driver.SwitchTo().DefaultContent();

            wait.Until(ExpectedConditions.TitleContains(@"Donate-error - Payments"));

            var lblFirstHeader = driver.FindElementById(@"firstHeading");

            Assert.AreEqual("Donate-error", lblFirstHeader.Text);

        }


        [TestMethod]
        public void XPath_vs_CSS_test_yandex()
        {
            RemoteWebDriver driver = new InternetExplorerDriver();
            // Navigate to the base url.
            driver.Navigate().GoToUrl(@"http://yandex.ru");

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();

            for (int i = 0; i < 10; i++)
            {
                driver.FindElementByXPath("//div");
            }
            sw2.Stop();

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();

            for (int i = 0; i < 10; i++)
            {
                driver.FindElementsByCssSelector("div");
            }
            sw1.Stop();



            Console.WriteLine("CSS: " + sw1.ElapsedMilliseconds);
            Console.WriteLine("XPath: " + sw2.ElapsedMilliseconds);

        }

    }
}
