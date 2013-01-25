using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace WebDriverStarterMSTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MyWebdriverStarterTests
    {

        [TestMethod]
        public void Test_donations_invalid_credit_card()
        {
            RemoteWebDriver Driver = new InternetExplorerDriver();
            Driver.Navigate().GoToUrl(@"http://en.wikipedia.org/");

            // On Main Page
            var lnkSupportUs = Driver.FindElementByCssSelector(@"a[title='Support us']");
            lnkSupportUs.Click();

            // On Make your donation page
            
            var radio50UAH = Driver.FindElementByCssSelector(@"#input_amount_0[value='50']");
            radio50UAH.Click(); 

            
            // And clich on "Donate" button
            var btnDonate = Driver.FindElementByCssSelector(@"input[value='Donate by credit/debit card']");
            btnDonate.Click();

            
            // On Billing information

            var txtFirstName = Driver.FindElementByName("fname");
            var txtLastName = Driver.FindElementByName("lname");
            var txtStreet = Driver.FindElementByName("street");
            var txtPostalCode = Driver.FindElementByName("zip");
            var txtCity = Driver.FindElementByName("city");
            var txtEmailAddress = Driver.FindElementByName("emailAdd");

            var radioCardType = Driver.FindElementByCssSelector(@"input[name='cardtype'][value='visa']");


            txtFirstName.Clear();
            txtFirstName.SendKeys("Vasya");

            txtLastName.Clear();
            txtLastName.SendKeys("Poopkin");

            txtCity.Clear();
            txtCity.SendKeys("Kyiv");

            txtEmailAddress.Clear();
            txtEmailAddress.SendKeys("hello@example.com");

            txtPostalCode.Clear();
            txtPostalCode.SendKeys("80999");

            txtStreet.Clear();
            txtStreet.SendKeys("It is very boring");

            radioCardType.Click();


            // Donation form second part

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            
            string frameSelector = @"div#payment > iframe";

            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(frameSelector)));

            var frameFormSecondPart = Driver.FindElementByCssSelector(frameSelector);

            Driver.SwitchTo().Frame(frameFormSecondPart);

            string cardNumSelector = @"CREDITCARDNUMBER";
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(cardNumSelector)));

            var txtCreditCardNum = Driver.FindElementByName(cardNumSelector);
            var selectExpMonth = new SelectElement(Driver.FindElementByName(@"EXPIRYDATE_MM"));
            var selectExpYear = new SelectElement(Driver.FindElementByName(@"EXPIRYDATE_YY"));
            var txtCVV = Driver.FindElementByName(@"CVV");
            var btnSubmit = Driver.FindElementById(@"btnSubmit");

            txtCreditCardNum.Clear();
            txtCreditCardNum.SendKeys("4716699955349929");

            selectExpMonth.SelectByText("02");
            selectExpYear.SelectByText("15");
            
            txtCVV.Clear();
            txtCVV.SendKeys("555");

            // Looks like we cannot click on this button. 
            // Well... 
            btnSubmit.SendKeys(Keys.Enter);

            Driver.SwitchTo().DefaultContent();

            // On Donate result page

            string headerSelector = @"h1.firstHeading";
            var headingElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(headerSelector)));

            Assert.AreEqual("Donate-error", headingElement.Text);

            // Looks like we are done!
            //Driver.Dispose();

            
        }

        [TestMethod]
        public void Test_for_donation_error_text()
        {
            RemoteWebDriver Driver = new InternetExplorerDriver();
            Driver.Navigate().GoToUrl(@"http://en.wikipedia.org/");

            // On Main Page
            var lnkSupportUs = Driver.FindElementByCssSelector(@"a[title='Support us']");
            lnkSupportUs.Click();

            // On Make your donation page

            var radio50UAH = Driver.FindElementByCssSelector(@"#input_amount_0[value='50']");
            radio50UAH.Click();


            // And clich on "Donate" button
            var btnDonate = Driver.FindElementByCssSelector(@"input[value='Donate by credit/debit card']");
            btnDonate.Click();


            // On Billing information

            var txtFirstName = Driver.FindElementByName("fname");
            var txtLastName = Driver.FindElementByName("lname");
            var txtStreet = Driver.FindElementByName("street");
            var txtPostalCode = Driver.FindElementByName("zip");
            var txtCity = Driver.FindElementByName("city");
            var txtEmailAddress = Driver.FindElementByName("emailAdd");

            var radioCardType = Driver.FindElementByCssSelector(@"input[name='cardtype'][value='visa']");


            txtFirstName.Clear();
            txtFirstName.SendKeys("Vasya");

            txtLastName.Clear();
            txtLastName.SendKeys("Poopkin");

            txtCity.Clear();
            txtCity.SendKeys("Kyiv");

            txtEmailAddress.Clear();
            txtEmailAddress.SendKeys("hello@example.com");

            txtPostalCode.Clear();
            txtPostalCode.SendKeys("80999");

            txtStreet.Clear();
            txtStreet.SendKeys("It is very boring");

            radioCardType.Click();


            // Donation form second part

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

            string frameSelector = @"div#payment > iframe";

            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(frameSelector)));

            var frameFormSecondPart = Driver.FindElementByCssSelector(frameSelector);

            Driver.SwitchTo().Frame(frameFormSecondPart);

            string cardNumSelector = @"CREDITCARDNUMBER";
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(cardNumSelector)));

            var txtCreditCardNum = Driver.FindElementByName(cardNumSelector);
            var selectExpMonth = new SelectElement(Driver.FindElementByName(@"EXPIRYDATE_MM"));
            var selectExpYear = new SelectElement(Driver.FindElementByName(@"EXPIRYDATE_YY"));
            var txtCVV = Driver.FindElementByName(@"CVV");
            var btnSubmit = Driver.FindElementById(@"btnSubmit");

            txtCreditCardNum.Clear();
            txtCreditCardNum.SendKeys("4716699955349929");

            selectExpMonth.SelectByText("02");
            selectExpYear.SelectByText("15");

            txtCVV.Clear();
            txtCVV.SendKeys("555");

            // Looks like we cannot click on this button. 
            // Well... 
            btnSubmit.SendKeys(Keys.Enter);

            Driver.SwitchTo().DefaultContent();

            // On Donate result page

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(@"div#mw-content-text * big > span")));
            var lblTransactionErrorMessage = Driver.FindElement(By.CssSelector(@"div#mw-content-text * big > span"));

            Assert.AreEqual("Your transaction could not be accepted.", lblTransactionErrorMessage.Text);

            Driver.Dispose();

        }
    }
}
