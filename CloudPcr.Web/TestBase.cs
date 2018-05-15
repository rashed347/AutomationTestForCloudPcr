using System;
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

                driver = new ChromeDriver();
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

