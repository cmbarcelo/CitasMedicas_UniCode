using System.Web;
using System.Web.Mvc;

namespace CitasMedicas_UniCode
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
