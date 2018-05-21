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
            Assert.That(CldWeb.LoginPage.Login("ratul", "one_2_three")
                .IsDashboardTitleDisplayed(), "User Failed to login");
            
        }

        [Test]
        public void LoginWithInvalidCredential()
        {
            Assert.That(CldWeb.LoginPage.Login("ra1", "one_2_three")
                .IsDashboardTitleDisplayed(), "User can't Login");
        }
    }
}
