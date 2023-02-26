using System.Web.Mvc;

namespace jqGrillaASP
{
    public static class GrillaHelper
    {
        public static Grilla Grilla(this HtmlHelper helper, string id = "grid", string pagina = "pager")
        {
            return new Grilla(id, pagina);
        }
    }
}
