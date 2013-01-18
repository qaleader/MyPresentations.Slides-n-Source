using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DemoTest.FinalPageObject.Pages;
namespace DemoTest.FinalPageObject.ExpectedControlsTest.PagesTest
{
    [TestClass]
    public class MainPage_ExpectedControls : ExpectedControlsTestBase
    {
        public override IHaveExpectedControls CurrentPage
        {
            get
            {
                return MyPages.MainPage;
            }
        }
    }
}
