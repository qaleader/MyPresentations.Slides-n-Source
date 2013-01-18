using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DemoTest.FinalPageObject.Pages;

namespace DemoTest.FinalPageObject
{
    [TestClass]
    public class AllPagesTest
    {
        public void TestThatPageExists(IInvokable page)
        {
            page.Invoke();
            var pageClassName = page.GetType().ToString();

            Assert.IsTrue(page.Exists(), "Page should exist: " + pageClassName);
            
            Console.WriteLine(pageClassName + "Done. Current title is: "
                              + WebBrowser.Driver.Title);
        }
        
        [TestMethod]
        public void Test_PaymentResultErrorInvalidCreditCard()
        {
            TestThatPageExists(MyPages.PaymentResultErrorInvalidCreditCard);
        }

        [TestMethod]
        public void Test_DonationPaymentsForm()
        {
            TestThatPageExists(MyPages.DonationPaymentsForm);
        }

        [TestMethod]
        public void Test_MainPage()
        {
            TestThatPageExists(MyPages.MainPage);
        }

        [TestMethod]
        public void Test_DonatePage()
        {
            TestThatPageExists(MyPages.DonatePage);
        }
    }
}
