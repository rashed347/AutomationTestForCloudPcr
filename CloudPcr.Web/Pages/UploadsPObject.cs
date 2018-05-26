using OpenQA.Selenium;

namespace CloudPcr.Web.Pages
{
    public class UploadsPObject
    {
        IWebElement Title => TestBase.driver.FindElement(By
            .XPath(".//h3/span[text() = 'Uploads']"));

        public string UploadsPageTitle()
        {
            return Title.Text;
        }
    }
}
