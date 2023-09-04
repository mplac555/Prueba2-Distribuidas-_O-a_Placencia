using System.Web;
using System.Web.Mvc;

namespace ad_ona_placencia_prueba_2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
