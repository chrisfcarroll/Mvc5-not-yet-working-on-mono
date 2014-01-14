using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc4CSharpRazorFx45Intranet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcAssembly = typeof(HtmlHelper).Assembly;
            var razorAssembly = typeof(System.Web.Razor.CSharpRazorCodeLanguage).Assembly;
            ViewBag.Message = "ASP.NET MVC dlls: <br/>" +
                    string.Format("MVC: {0} from {1} <br/>", mvcAssembly.FullName, mvcAssembly.Location) +
                    string.Format("Razor: {0} from {1} <br/>", razorAssembly.FullName, razorAssembly.Location); 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
