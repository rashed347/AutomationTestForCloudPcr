using NUnit.Framework;
using System.Threading;
using CloudPcr.Web;

namespace CloudPcr.Tests
{
    public class Tests:TestBase
    {
        [Test]
        public void ShouldNotLoginWithInvalidCredential()
        {
            Assert.That(CldWeb.LoginPage.LoginWithInvalidCredential("ra1", "one_2_three")
                .GetErrMsg().Equals("Login failed!"), "Error popup is not appeared");
        }

        [Test]
        public void ShouldLoginToCloudPcrWithValidCredential()
        {
           // Assert.That(CldWeb.LoginPage.IsTitleDisplayed(), "It takes more than ten second to load");
            Assert.That(CldWeb.LoginPage.LoginWithValidCredential("ratul", "one_2_three")
                .DashboardText().Equals("Dashboard"), "User unable to login with valid credential");
        }

        [TestCase("", "")]
        [TestCase("", "123")]
        [TestCase("ratul", "")]
        public void ShouldBeInLogInPageWhenUserTryToLogInWithEmptyCredential(string userName, string password)
        {
            Assert.That(CldWeb.LoginPage.LoginWithoutCredential(userName, password).IsAtPage());
        }

        [Test]
        public void ShouldLandingOnUploadPage()
        {
            CldWeb.LoginPage.LoginWithValidCredential("ratul", "one_2_three");
            Assert.That(CldWeb.NavigationMenu.NavigateToUploadsPage()
                .UploadsPageTitle().Equals("Uploads"), "Uploads page is not appeared");
        }
    }
}
