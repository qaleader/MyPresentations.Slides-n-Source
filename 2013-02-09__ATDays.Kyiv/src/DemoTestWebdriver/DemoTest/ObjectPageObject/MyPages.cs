﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

using DemoTest.ObjectPageObject.Pages;


namespace DemoTest.ObjectPageObject
{
    public static class MyPages
    {
        public static MainPage MainPage
        {
            get { return new MainPage();}
        }

        public static DonatePage DonatePage
        {
            get { return new DonatePage(); }
        }

        public static DonationPaymentsForm DonationPaymentsForm
        {
            get { return new DonationPaymentsForm(); }
        }

        public static PaymentResultPage PaymentResultPage
        {
            get { return new PaymentResultPage(); }
        }
    }
}
