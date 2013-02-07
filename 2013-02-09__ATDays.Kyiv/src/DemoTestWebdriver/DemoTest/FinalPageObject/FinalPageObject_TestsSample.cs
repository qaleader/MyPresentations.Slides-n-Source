using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using DemoTest.FinalPageObject.Pages;

namespace DemoTest.FinalPageObject
{
    [TestClass]
    public class FinalPageObject_TestsSample
    {

        public RemoteWebDriver Driver
        {
            get { return WebBrowser.Driver; }
        }

        [TestMethod]
        public void Donate_test_object_v2()
        {
            MyPages.MainPage.Open();
            MyPages.MainPage.GoToDonatePage();
            MyPages.DonatePage.Donate_50_UAH_Using_Debit_Card();
            MyPages.DonationPaymentsForm.FillDonationForm
                (
                    firstName : "Vasya", 
                    lastName : "Pupkin", 
                    street : "Blah blah blah street", 
                    postalCode : "8577",
                    city : "My City",
                    emailAddress : "valid@example.com",
                    cardNumber : "4556767453966453", 
                    expirationDateMonth : "05", 
                    expirationDateYear : "15",
                    securityCode : "555"

                );
            MyPages.PaymentResultPage.WaitUntilExists();
            string paymentResult = MyPages.PaymentResultPage.GetResultHeaderText();
            Assert.AreEqual("Donate-error", paymentResult);
        }



        [TestMethod]
        public void Test_for_donation_error_text()
        {

            var donationErrorPage = MyPages.PaymentResultErrorInvalidCreditCard; 
            donationErrorPage.Invoke();

            Assert.AreEqual("Your transaction could not be accepted."
                            , donationErrorPage.GetErrorDetailsText());

        }

        [TestMethod]
        public void Test_for_donation_error_status_header()
        {

            var donationErrorPage = MyPages.PaymentResultErrorInvalidCreditCard;
            donationErrorPage.Invoke();

            Assert.AreEqual("Donate-error"
                            , donationErrorPage.GetResultHeaderText());

        }

        [TestMethod]
        public void Test_Expected_Controls_Exist()
        {
            IHaveExpectedControls somePage = MyPages.LoginPage;
            somePage.Invoke();

            foreach (var control in somePage.GetExpectedControls())
            {
                Console.WriteLine(control.Location + " " + control.TagName);
            }
        }


    }
}
