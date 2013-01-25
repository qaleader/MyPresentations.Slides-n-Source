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


        [TestMethod]
        public void Donate_error_test()
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

    }
}
