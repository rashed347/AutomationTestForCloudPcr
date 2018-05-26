using OpenQA.Selenium;

namespace CloudPcr.Web.Pages
{
   public class LoginPObject
    {
        protected IWebElement LoginPageTitle { get; set; }

        protected IWebElement UserName { get; set; }

        protected IWebElement Password { get; set; }

        protected IWebElement LoginBtn { get; set; }

        
        
        /// <summary>
        /// Determines whether [is title displayed].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is title displayed]; otherwise, <c>false</c>.
        /// </returns>

        public bool IsTitleDisplayed()
        {
            LoginPageTitle = TestBase.driver.FindElement(By.XPath(".//h3[@class = 'm-login__title']"));
            return LoginPageTitle.Displayed;
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
            UserName = TestBase.driver.FindElement(By.XPath(".//input[@name = 'userNameOrEmailAddress']"));
            UserName.SendKeys(userName);

            Password = TestBase.driver.FindElement(By.XPath(".//input[@name = 'password']"));
            Password.SendKeys(password);

            LoginBtn = TestBase.driver.FindElement(By.XPath(".//button[@type = 'submit']"));
            LoginBtn.Click();
        }

        
    }
}
