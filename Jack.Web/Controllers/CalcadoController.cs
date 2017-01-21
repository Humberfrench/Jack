using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Calcado")]
    public class CalcadoController : BaseController
    {
        #region Vars

        private readonly ICalcadoServiceApp calcadoAppService;

        #endregion

        #region Ctor

        public CalcadoController(ICalcadoServiceApp calcadoAppService)
        {
            this.calcadoAppService = calcadoAppService;
        }

        #endregion

        #region Public Methods

        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Calçado",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Calçado", ActionName = "Index", ControllerName = "Calcado"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Calcado"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = calcadoAppService.ObterTodos();
            return View(listaDados);
        }

        [Route("Meninas")]
        public ActionResult Meninas()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Calçado",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Calçado", ActionName = "Index", ControllerName = "Calcado"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Calcado"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = calcadoAppService.ObterTodos().Where(c => c.Sexo == "F"); ;
            return View("Index", listaDados);
        }

        [Route("Meninos")]
        public ActionResult Meninos()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Calçado",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Calçado", ActionName = "Index", ControllerName = "Calcado"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Calcado"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = calcadoAppService.ObterTodos().Where(c => c.Sexo == "M");
            return View("Index",listaDados);
        }

        #endregion
    }
}