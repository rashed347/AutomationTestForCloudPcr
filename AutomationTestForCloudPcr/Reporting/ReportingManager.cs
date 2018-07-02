using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;


namespace AutomationTestForCloudPcr.Reporting
{
    public class ReportingManager
    {
        private ExtentReports _extent;
        private ExtentTest _test;
        private ExtentHtmlReporter _htmlReporter;
        private string _workingDir;


        static readonly ReportingManager _instance = new ReportingManager();
        public static ReportingManager Instance => _instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingManager"/> class.
        /// </summary>
        /// <param name="extentInstance">The extent instance.</param>
        private ReportingManager()
        {
            InitializeTest();
        }

        /// <summary>
        /// Initializes the test for reporting.
        /// runs at the beginning of every test
        /// </summary>
        private void InitializeTest()
        {
            _workingDir = TestContext.CurrentContext.TestDirectory + "\\";
            var fileName = "TestResult.html";
            _htmlReporter = new ExtentHtmlReporter(_workingDir + fileName);
            _extent = new ExtentReports();
            _extent.AttachReporter(_htmlReporter);
        }


        public void StartTest(string test)
        {
            _test = _extent.CreateTest(test);
        }


        public void ReportTest(string test)
        {
        }

        /// <summary>
        /// Finalizes the test.
        /// Runs at the end of every test
        /// </summary>
        public void FinalizeTest(IWebDriver driver)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    if (driver != null)
                    {
                        try
                        {
                            if (driver.WindowHandles != null)
                                try
                                {
                                    foreach (var window in driver.WindowHandles)
                                    {
                                        driver.SwitchTo().Window(window);
                                        var currentShotName = string.Concat("SS-", Guid.NewGuid().ToString(),
                                            ".jpeg");
                                        GetScreenshot(driver, string.Format("{0}{1}{2}", _workingDir, "\\", currentShotName));
                                        _test.AddScreenCaptureFromPath(currentShotName);
                                    }
                                }
                                finally
                                {
                                    driver.SwitchTo().DefaultContent();
                                }

                        }
                        catch (Exception)
                        {

                        }
                    }
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
        }

        /// <summary>
        /// Cleans up reporting.
        /// Runs after all the test finishes
        /// </summary>
        public void CleanUpReporting()
        {
            _extent.Flush();
        }

        public void LoadConfig(string configPath)
        {
            if (File.Exists(configPath))
            {
                _htmlReporter.LoadConfig(configPath);
                return;
            }
        }

        public void AddSystemInfo(string item, string value)
        {
            _extent.AddSystemInfo(item, value);
        }

        /// <summary>
        /// Gets the decoded screen shot.
        /// </summary>
        public void GetScreenshot(IWebDriver driver, string fileName)
        {
            var imageBytes = Convert.FromBase64String(CreateScreenshot(driver));
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                image.Save($"{fileName}", ImageFormat.Jpeg);
            }
        }

        private string CreateScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string encodedScreenshot = screenshot.AsBase64EncodedString;
            return encodedScreenshot;
        }




    }
}


