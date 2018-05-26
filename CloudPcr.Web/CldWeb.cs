using CloudPcr.Web.Pages;

namespace CloudPcr.Web
{
    public class CldWeb
    {
        public static LoginPObject LoginPage
        {
            get
            {
                return new LoginPObject();
            }
        }

        public static DashboardPObject DashboardPage
        {
            get
            {
                return new DashboardPObject();
            }
        }

        public static NavigationMenuObject NavigationMenu
        {
            get
            {
                return new NavigationMenuObject();
            }
        }
    }
}
