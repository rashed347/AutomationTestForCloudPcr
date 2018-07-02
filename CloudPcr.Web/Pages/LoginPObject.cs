using AutomationTestForCloudPcr.Elements;
using OpenQA.Selenium;

namespace CloudPcr.Web.Pages
{
    public class LoginPObject
    {
        protected IWebElement LoginPageTitle => TestBase.driver.FindElement(By.XPath(".//h3[@class = 'm-login__title']"));

        protected IWebElement UserName => TestBase.driver.FindElement(By.XPath(".//input[@name = 'userNameOrEmailAddress']"),10);

        protected IWebElement Password => TestBase.driver.FindElement(By.XPath(".//input[@name = 'password']"));

        protected IWebElement LoginBtn => TestBase.driver.FindElement(By.XPath(".//button[@type = 'submit']"));



        /// <summary>
        /// Determines whether [is title displayed].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is title displayed]; otherwise, <c>false</c>.
        /// </returns>

        public bool IsTitleDisplayed()
        {
            return LoginPageTitle.Displayed;
        }

        public bool IsAtPage()
        {
            return LoginBtn.Displayed;
        }
        /// <summary>
        /// Logins the with invalid credential.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public LoginErrorPObject LoginWithInvalidCredential(string userName, string password)
        {
            PerformLogin(userName, password);
            return new LoginErrorPObject();
        }

        public LoginPObject LoginWithoutCredential(string userName, string password){

            PerformLogin(userName, password);
            return this;
        }

        /// <summary>
        /// Logins the with valid credential.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public DashboardPObject LoginWithValidCredential (string userName, string password)
        {
            PerformLogin(userName, password);
            return new DashboardPObject();
        }

        private void PerformLogin(string userName, string password)
        {
            UserName.SendKeys(userName);
            Password.SendKeys(password);
            LoginBtn.Click();
        }

        
    }
}
