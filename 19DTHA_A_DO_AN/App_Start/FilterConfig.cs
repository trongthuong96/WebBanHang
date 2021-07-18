using System.Web;
using System.Web.Mvc;

namespace _19DTHA_A_DO_AN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
