using NUnit.Framework;
using System.Threading;
using CloudPcr.Web;

namespace CloudPcr.Tests
{
    public class Tests:TestBase
    {
        [Test, Order(1)]
        public void ShouldNotLoginWithInvalidCredential()
        {
            Assert.That(CldWeb.LoginPage.LoginWithInvalidCredential("ra1", "one_2_three")
                .GetErrMsg().Equals("Login failed!"), "Error popup is not appeared");
        }

        [Test, Order(2)]
        public void ShouldLoginToCloudPcrWithValidCredential()
        {
            Assert.That(CldWeb.LoginPage.LoginWithValidCredential("ratul", "one_2_three")
                .DashboardText().Equals("Dashboard"), "User unable to login with valid credential");
        }

        [Test, Order(3)]
        public void ShouldLandingOnUploadPage()
        {
            CldWeb.LoginPage.LoginWithValidCredential("ratul", "one_2_three");
            Assert.That(CldWeb.NavigationMenu.NavigateToUploadsPage()
                .UploadsPageTitle().Equals("Uploads"), "Uploads page is not appeared");
        }
    }
}
