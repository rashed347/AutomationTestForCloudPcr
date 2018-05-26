using System;
using System.Collections.Generic;
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
                driver.Navigate().GoToUrl("http://bridge-app.azurewebsites.net/account/login");
            }

            [TearDown]
            public void TestCleanUp()
            {
                driver.Manage().Cookies.DeleteAllCookies();
            }

            public static void BeginExecution()
            {
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
            }
        }
    }

