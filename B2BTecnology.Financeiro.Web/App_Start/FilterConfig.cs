using System.Web;
using System.Web.Mvc;

namespace B2BTecnology.Financeiro.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}