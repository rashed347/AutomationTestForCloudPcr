using OpenQA.Selenium;

namespace CloudPcr.Web.Pages
{
   public class NavigationMenuObject
    {
        IWebElement Dashboard => TestBase.driver.FindElement(
            By.XPath(".//span[@class = 'm-menu__link-text']/span[text() = 'Dashboard']"));

        IWebElement Uploads => TestBase.driver.FindElement(
            By.XPath(".//span[@class = 'm-menu__link-text']/span[text() = 'Uploads']"));

        IWebElement AllPCRs => TestBase.driver.FindElement(
            By.XPath(".//span[@class = 'm-menu__link-text']/span[text() = 'All PCRs']"));

        IWebElement Demographics => TestBase.driver.FindElement(
            By.XPath(".//span[@class = 'm-menu__link-text']/span[text() = 'Demographics']"));

        public UploadsPObject NavigateToUploadsPage()
        {
            Uploads.Click();
            return new UploadsPObject();
        }
    }
}
