using System;
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
        [TestCategory("Automated")]
        [TestCategory("Addition")]
        [DataTestMethod]
        [DataRow("2", "2", "4")]
        [DataRow("10", "10", "20")]
        [DataRow("15", "5", "20")]
        [DataRow("100", "32", "132")]
        public void TestAddTwoIntegers(string left, string right, string result)
        {
            ConvertValueToClicks(left);

            var displayText = WindowsDriver.FindElementByAccessibilityId("DisplayLabelTextBlock").Text;
            Assert.AreEqual(left, displayText);

            WindowsDriver.FindElementByName("+").Click();

            ConvertValueToClicks(right);

            displayText = WindowsDriver.FindElementByAccessibilityId("DisplayLabelTextBlock").Text;
            Assert.AreEqual(right, displayText);

            WindowsDriver.FindElementByName("=").Click();

            displayText = WindowsDriver.FindElementByAccessibilityId("DisplayLabelTextBlock").Text;
            Assert.AreEqual(result, displayText);
        }

        private static void ConvertValueToClicks(string left)
        {
            foreach (var character in left)
            {
                switch (character)
                {
                    case '0':
                        //Scaling is throwing off the location of this control
                        WindowsDriver.FindElementByName("0").Click();
                        break;
                    case '1':
                        WindowsDriver.FindElementByAccessibilityId("OneButton").Click();
                        break;
                    case '2':
                        WindowsDriver.FindElementByAccessibilityId("TwoButton").Click();
                        break;
                    case '3':
                        WindowsDriver.FindElementByAccessibilityId("ThreeButton").Click();
                        break;
                    case '4':
                        WindowsDriver.FindElementByAccessibilityId("FourButton").Click();
                        break;
                    case '5':
                        WindowsDriver.FindElementByAccessibilityId("FiveButton").Click();
                        break;
                    case '6':
                        WindowsDriver.FindElementByAccessibilityId("SixButton").Click();
                        break;
                    case '7':
                        WindowsDriver.FindElementByAccessibilityId("SevenButton").Click();
                        break;
                    case '8':
                        WindowsDriver.FindElementByAccessibilityId("EightButton").Click();
                        break;
                    case '9':
                        WindowsDriver.FindElementByAccessibilityId("NineButton").Click();
                        break;
                    case '.':
                        WindowsDriver.FindElementByAccessibilityId("DecimalButton").Click();
                        break;
                    default:
                        throw new ArgumentException("Value must be an inteager or decimal.", nameof(left));
                }
            }
        }
    }
}