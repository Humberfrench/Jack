using System.Web;
using System.Web.Http.Filters;

namespace Jack.Web
{
    public class ElmahExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(context.Exception));
        }
    }
}