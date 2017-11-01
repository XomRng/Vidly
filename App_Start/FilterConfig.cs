using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Vidly.Models;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); // to dziala na wszystkie controlery i akcje, ten filtr jest odpalany przed i po akcji, jesli jest exception to go lapie i wyswietla error view z shared
            //ten filtr dziala tylko wtedy kiedy wystąpi exception, nie dziala na błędy 404, gdy chcemy odpalic cos co zwraca wynik akcji = 404
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute());


               
    }
    }
}
