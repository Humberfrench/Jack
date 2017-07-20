using System.Collections.Generic;
using System.Web.Mvc;
using Jack.Library;

namespace Jack.Web.Controllers
{
    public class ProcessarController : Controller
    {
        // GET: Processar
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Processar",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Processar", ActionName = "Index", ControllerName = "Processar"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            return View();
        }
    }
}