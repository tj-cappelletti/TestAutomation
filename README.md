# Test Automation
This project is provides developers with sample code and ways to automate testing of the sample code. The idea is to give developers working code with working samples and allow them to explore the various libraries without them having to start from scratch.

## Getting Started
The first step is to clone the repository and verify that you can build the appliaction. There are several NuGet packages that are referenced that will need to be restored on the first build. Once the solution is building, you may need to install third party tools in order to run certain examples.

### Appium
The project `TestAutomation.Wpf.Calculator.AutomatedTests` uses Appium to automate the testting of `TestAutomation.Wpf.Calculator.Demo` which is a .NET 4.6.1 WPF application. To execute the tests, follow the directions below.

1. Download the latest version of the [WinAppDriver](https://github.com/Microsoft/WinAppDriver/releases/latest) from Microsoft's GitHub repository. At present, the demo works with version `v1.0-RC`
2. Install the MSI or compile the code for the `WinAppDriver` (recommended to install the MSI)
3. Turn on `Developer mode` in Windows.
   a. For details on this, please read [Enable your device for development](https://docs.microsoft.com/en-us/windows/uwp/get-started/enable-your-device-for-development) in the Windows Dev Center
4. Launch the `WinAppDriver` as an Administrator
   a. If installed via MSI, launch a command prompt as an Administrator, navigate to `C:\Program Files (x86)\Windows Application Driver` and type `WinAppDriver` and hit enter
5. Launch Visual Studio as an Administrator and open the `TestAutomation` solution
6. Run tests with the test category of `Appium`

# Additional Reading
* Appium - <http://appium.io/>
* Microsoft's WinAppDriver - <https://github.com/Microsoft/WinAppDriver>
* WinAppDriver - Test any app with Appium's Selenium-like tests on Windows - <https://www.hanselman.com/blog/WinAppDriverTestAnyAppWithAppiumsSeleniumlikeTestsOnWindows.aspx>
