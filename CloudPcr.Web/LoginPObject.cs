using OpenQA.Selenium;

namespace CloudPcr.Web.Pages
{
   public class LoginPObject
    {
        protected IWebElement LoginPageTitle { get; set; }

        protected IWebElement UserName { get; set; }

        protected IWebElement Password { get; set; }

        protected IWebElement LoginBtn { get; set; }

        public bool IsTitleDisplayed()
        {
            LoginPageTitle = TestBase.driver.FindElement(By.XPath(".//h3[@class = 'm-login__title']"));
            return LoginPageTitle.Displayed;
        }

        public DashboardPObject Login (string userName, string password)
        {
            UserName = TestBase.driver.FindElement(By.XPath(".//input[@name = 'userNameOrEmailAddress']"));
            UserName.SendKeys(userName);

            Password = TestBase.driver.FindElement(By.XPath(".//input[@name = 'password']"));
            Password.SendKeys(password);

            LoginBtn = TestBase.driver.FindElement(By.XPath(".//button[@type = 'submit']"));
            LoginBtn.Click();
            return new DashboardPObject();
        }
    }
}
