using System.Web;
using System.Web.Mvc;

namespace Mvc5CSharpRazorFx45Internet
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
