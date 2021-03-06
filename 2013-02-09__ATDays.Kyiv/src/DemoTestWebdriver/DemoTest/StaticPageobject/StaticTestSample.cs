﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace DemoTest.StaticPageobject
{
    [TestClass]
    public class StaticTestSample
    {

        public static RemoteWebDriver Driver { get { return WebBrowser.Driver; } }

        [TestMethod]
        public void Donate_test_static()
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


    }
}
