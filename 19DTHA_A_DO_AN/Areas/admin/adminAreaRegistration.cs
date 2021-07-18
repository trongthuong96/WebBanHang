using System.Web.Mvc;

namespace _19DTHA_A_DO_AN.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index",Controller="Products" , id = UrlParameter.Optional }
            );
        }
    }
}