using System.Web;
using System.Web.Mvc;

namespace Tp5_API_Grupo9B
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
