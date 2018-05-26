using OpenQA.Selenium;
using System.Threading;

namespace CloudPcr.Web.Pages
{
   public class LoginErrorPObject
    {
        IWebElement ErrorText => TestBase.driver
            .FindElement(By.XPath(".//div[@class = 'swal-title']"));

        public string GetErrMsg()
        {
            WaitFor(ErrorText);
            return ErrorText.Text;
        }

        public void WaitFor(IWebElement element)
        {
            for(int i = 0; i<20; i++)
            {
                if (element.Displayed)
                    break;
                else
                    Thread.Sleep(500);
            }
        }
    }
}
