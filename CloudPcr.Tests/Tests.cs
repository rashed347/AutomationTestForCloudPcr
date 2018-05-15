using NUnit.Framework;
using System.Threading;
using CloudPcr.Web;

namespace CloudPcr.Tests
{
    public class Tests:TestBase
    {
        [Test]
        public void ShouldLoginToCloudPcrWithValidCredential()
        {
            CldWeb.LoginPage.Login("ratul", "one_2_three").IsDashboardTitleDisplayed();
        }
    }
}
