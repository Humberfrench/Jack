using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jack.Application.Interfaces;
using Jack.Library;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Roupa")]
    public class RoupaController : Controller
    {
        #region Vars

        private readonly IRoupaServiceApp roupaAppService;

        #endregion

        #region Ctor

        public RoupaController(IRoupaServiceApp roupaAppService)
        {
            this.roupaAppService = roupaAppService;
        }

        #endregion

        #region Public Methods

        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Roupas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Roupas", ActionName = "Index", ControllerName = "Roupa"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Roupa"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = roupaAppService.ObterTodos();
            return View(listaDados);
        }

        #endregion   
    }
}