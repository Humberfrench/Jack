using Jack.Library;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : BaseController
    {
        // GET: Home
        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Home",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Home", ActionName = "Index", ControllerName = "Home"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            return View();
        }
    }
}