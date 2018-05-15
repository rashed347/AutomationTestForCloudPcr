using NUnit.Framework;
using CloudPcr.Web;

namespace CloudPcr.Tests
{
    [SetUpFixture]
    public class TestSetup
    {

        [OneTimeSetUp]
        public void Start()
        {
            TestBase.BeginExecution();
        }

        [OneTimeTearDown]

        public void End()
        {
            TestBase.ExitExecution();
        }
    }
}
