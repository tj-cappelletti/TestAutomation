using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAutomation.Wpf.Calculator.AutomatedTests
{
    [TestClass]
    public class AdditionTests : DemoAppSession
    {
        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Close the application and delete the session
            TearDown();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
        }

        [TestMethod]
        [TestCategory("Automated"), TestCategory("Addition")]
        public void TestAddTwoIntegers()
        {
            WindowsDriver.FindElementByAccessibilityId("TwoButton").Click();

            var displayText = WindowsDriver.FindElementByAccessibilityId("DisplayLabelTextBlock").Text;
            Assert.AreEqual("2", displayText);

            WindowsDriver.FindElementByAccessibilityId("AddButton").Click();

            WindowsDriver.FindElementByAccessibilityId("TwoButton").Click();

            displayText = WindowsDriver.FindElementByAccessibilityId("DisplayLabelTextBlock").Text;
            Assert.AreEqual("2", displayText);

            WindowsDriver.FindElementByAccessibilityId("EqualsButton").Click();

            displayText = WindowsDriver.FindElementByAccessibilityId("DisplayLabelTextBlock").Text;
            Assert.AreEqual("4", displayText);
        }
    }
}
