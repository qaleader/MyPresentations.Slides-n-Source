using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace DemoTest.FinalPageObject.Pages
{
    public interface IHaveExpectedControls : IInvokable
    {
        List<IWebElement> GetExpectedControls();
    }
}
