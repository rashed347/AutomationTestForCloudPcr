using OpenQA.Selenium;

namespace CloudPcr.Web.Pages
{
    public class DashboardPObject
    {
        IWebElement DashboardTitle => TestBase.driver.FindElement(By
            .XPath(".//h3/span[text() = 'Dashboard']"));

        public bool IsDashboardTitleDisplayed()
        {
            
            return DashboardTitle.Displayed;
        }

        public string DashboardText()
        {
            
            return DashboardTitle.Text;
        }
    }
}
