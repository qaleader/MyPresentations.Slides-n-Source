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
    public class DonationPaymentsForm : AbstractPageBase, IHaveExpectedControls
    {

        [FindsBy(Using = @"fname", How = How.Name)]
        public IWebElement txtFirstName;

        [FindsBy(Using = @"lname", How = How.Name)]
        public IWebElement txtLastName;

        [FindsBy(Using = @"street", How = How.Name)]
        public IWebElement txtStreet;

        [FindsBy(Using = @"zip", How = How.Name)]
        public IWebElement txtPostalCode;

        [FindsBy(Using = @"city", How = How.Name)]
        public IWebElement txtCity;

        [FindsBy(Using = @"emailAdd", How = How.Name)]
        public IWebElement txtEmailAddress;

        [FindsBy(Using = @"input[name='cardtype'][value='visa']", How = How.CssSelector)]
        public IWebElement rbtnCardVisa;

        
        // Why not FindsBy? :
        // Test method DemoTest.FinalPageObject.FinalPageObject_TestsSample.Donate_test_object_v2 threw exception: 
        // System.ArgumentException: frameElement cannot be converted to RemoteWebElement
        // Parameter name: frameElement
        public IWebElement frameCardNumber
        {
            get
            {
                return Driver.FindElementByCssSelector(@"iframe[src^='https://na.gcsip.com/orb/']");
            }
        }

        
        // ============ Card Number Frame

        [FindsBy(Using = @"CREDITCARDNUMBER", How = How.Name)]
        public IWebElement txtName;

        [FindsBy(Using = @"EXPIRYDATE_MM", How = How.Name)]
        public IWebElement ddlMonthSelectElement;

        [FindsBy(Using = @"EXPIRYDATE_YY", How = How.Name)]
        public IWebElement ddlYearSelectElement;

        [FindsBy(Using = @"CVV", How = How.Name)]
        public IWebElement txtSecurityCode;

        [FindsBy(Using = @"btnSubmit", How = How.Id)]
        public IWebElement btnContinue;




        
        public void FillDonationForm(string firstName, string lastName, string street,
                                            string postalCode, string city, string emailAddress,
                                            string cardNumber, string expirationDateMonth, string expirationDateYear,
                                            string securityCode)
        {

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

            WebBrowser.WaitUntilVisible(() => frameCardNumber, 20);
                                  

            Driver.SwitchTo().Frame(frameCardNumber);

            WebBrowser.WaitUntilVisible(() => txtName, 20);

            txtName.Clear();
            txtName.SendKeys(cardNumber);

            var ddlMonthSelect = new SelectElement(ddlMonthSelectElement);
            var ddlYearSelect = new SelectElement(ddlYearSelectElement);
            
            ddlMonthSelect.SelectByText(expirationDateMonth);
            ddlYearSelect.SelectByText(expirationDateYear);
            txtSecurityCode.SendKeys(securityCode);

            btnContinue.SendKeys(Keys.Enter);

            Driver.SwitchTo().DefaultContent();

        }

        public void Invoke()
        {
            if (Exists() == false)
            {
                var donatePage = MyPages.DonatePage;
                donatePage.Invoke();
                donatePage.Donate_50_UAH_Using_Debit_Card();
            }
        }

        public bool Exists()
        {
            return Driver.Url == @"https://payments.wikimedia.org/index.php/Special:GlobalCollectGateway?uselang=en&form_name=RapidHtml&appeal=JimmyQuote&ffname=cc-vma";
        }

        public List<IWebElement> GetExpectedControls()
        {
            return new List<IWebElement>() 
            {
                txtFirstName,
                txtLastName,
                txtStreet,
                txtPostalCode,
                txtCity,
                txtEmailAddress,
                rbtnCardVisa,
            };
        }
    }
}
