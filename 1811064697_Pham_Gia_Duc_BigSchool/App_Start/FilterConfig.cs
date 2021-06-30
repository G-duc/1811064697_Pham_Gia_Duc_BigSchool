using System.Web;
using System.Web.Mvc;

namespace _1811064697_Pham_Gia_Duc_BigSchool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
