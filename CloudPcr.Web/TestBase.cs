using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AutomationTestForCloudPcr.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CloudPcr.Web
{
   
        [TestFixture]
        public abstract class TestBase
        {
            internal static IWebDriver driver;

            [SetUp]
            public void TestSetup()
            {
            ReportingManager.Instance.StartTest(TestContext.CurrentContext.Test.Name);
            driver.Navigate().GoToUrl("http://bridge-app.azurewebsites.net/account/login");
            }

            [TearDown]
            public void TestCleanUp()
            {
            ReportingManager.Instance.FinalizeTest(driver);
            driver.Manage().Cookies.DeleteAllCookies();
            }

            public static void BeginExecution()
            {
            var directoryInfo = Directory.GetParent(Assembly.GetExecutingAssembly().Location.ToString());
            ReportingManager.Instance.LoadConfig(directoryInfo.FullName + "\\extent-config.xml");
            ReportingManager.Instance.AddSystemInfo("Browser", "Chrome");

            ChromeOptions option = new ChromeOptions();
            //option.AddArgument("--headless");
           
            driver = new ChromeDriver(option);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                driver.Manage().Window.Maximize();
            }

            public static void ExitExecution()
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            ReportingManager.Instance.CleanUpReporting();
        }
        }
    }

