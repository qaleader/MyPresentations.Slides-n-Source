using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DemoTest.FinalPageObject.Pages;


namespace DemoTest.FinalPageObject.ExpectedControlsTest
{
    [TestClass]
    public abstract class ExpectedControlsTestBase
    {
        public virtual IHaveExpectedControls CurrentPage { get { return null; } }

        [TestMethod]
        public void TestExpectedControls()
        {
            CurrentPage.Invoke();
            
            var expectedControls = CurrentPage.GetExpectedControls();
            foreach (var expectedControl in expectedControls)
            {
                Console.WriteLine("Testing: " + expectedControl.ToString());
                Assert.IsTrue(expectedControl.Displayed, "for " + expectedControl.ToString());
            }

        }
    }
}
