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
    public class DonationPaymentsForm : AbstractPageBase
    {
        public void FillDonationForm(string firstName, string lastName, string street,
                                            string postalCode, string city, string emailAddress,
                                            string cardNumber, string expirationDateMonth, string expirationDateYear,
                                            string securityCode)
        {
            // Donation Payments
            var txtFirstName = Driver.FindElementByName("fname");
            var txtLastName = Driver.FindElementByName("lname");
            var txtStreet = Driver.FindElementByName("street");
            var txtPostalCode = Driver.FindElementByName("zip");
            var txtCity = Driver.FindElementByName("city");
            var txtEmailAddress = Driver.FindElementByName("emailAdd");
            var rbtnCardVisa = Driver.FindElementByCssSelector(@"input[name='cardtype'][value='visa']");


            txtFirstName.Clear();
            txtFirstName.SendKeys(firstName);

            txtLastName.Clear();
            txtLastName.SendKeys(lastName);

            txtStreet.Clear();
            txtStreet.SendKeys(street);

            txtPostalCode.Clear();
            txtPostalCode.SendKeys(postalCode);

            txtCity.Clear();
            txtCity.SendKeys(city);

            txtEmailAddress.Clear();
            txtEmailAddress.SendKeys(emailAddress);

            rbtnCardVisa.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));


            var frameCardNumber = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(@"iframe[src^='https://na.gcsip.com/orb/']")));

            Driver.SwitchTo().Frame(frameCardNumber);

            var txtName = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("CREDITCARDNUMBER")));

            txtName.Clear();
            txtName.SendKeys(cardNumber);

            var ddlMonthSelect = new SelectElement(Driver.FindElementByName(@"EXPIRYDATE_MM"));
            var ddlYearSelect = new SelectElement(Driver.FindElementByName(@"EXPIRYDATE_YY"));
            var txtSecurityCode = Driver.FindElementByName(@"CVV");
            var btnContinue = Driver.FindElementById("btnSubmit");

            ddlMonthSelect.SelectByText(expirationDateMonth);
            ddlYearSelect.SelectByText(expirationDateYear);
            txtSecurityCode.SendKeys(securityCode);

            btnContinue.SendKeys(Keys.Enter);

            Driver.SwitchTo().DefaultContent();

        }
    }
}
