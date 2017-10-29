using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [OutputCache(Duration = 50, Location =  OutputCacheLocation.Server, VaryByParam = "*")] // takie cos sprawia ze dany view jest przechowywane w cashe u klienta
        //i nastepnym razem gdy odwiedzi strone, nie bedzie ona wywolywala zapytan sql itp do serwera
        //tylko wczyta sie z pamieci klienta
        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)] // disabling caching
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}