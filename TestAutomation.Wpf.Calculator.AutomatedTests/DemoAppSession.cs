using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace TestAutomation.Wpf.Calculator.AutomatedTests
{
    public class DemoAppSession
    {
        //TODO: Move to a config file
        private const string DemoAppRelativepath = @"..\..\..\TestAutomation.Wpf.Calculator.Demo\bin\Debug\TestAutomation.Wpf.Calculator.Demo.exe";

        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";

        protected static WindowsDriver<WindowsElement> WindowsDriver;

        public static void Setup(TestContext context)
        {
            if (WindowsDriver != null) return;

            var demoAppFullPath = Path.GetFullPath(DemoAppRelativepath);

            // Create a new session to launch application
            var desiredCapabilities = new DesiredCapabilities();
            desiredCapabilities.SetCapability("app", demoAppFullPath);
            WindowsDriver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), desiredCapabilities);
            Assert.IsNotNull(WindowsDriver);
            Assert.IsNotNull(WindowsDriver.SessionId);

            // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
            WindowsDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
        }

        public static void TearDown()
        {
            if (WindowsDriver == null) return;

            WindowsDriver.Quit();
            WindowsDriver = null;
        }
    }
}