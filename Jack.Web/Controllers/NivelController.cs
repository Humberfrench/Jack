using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Nivel")]
    public class NivelController : BaseController
    {
        #region Vars

        private readonly INivelServiceApp nivelAppService;

        #endregion

        #region Ctor

        public NivelController(INivelServiceApp nivelAppService)
        {
            this.nivelAppService = nivelAppService;
        }

        #endregion

        #region Public Methods
        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Nível",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Nível", ActionName = "Index", ControllerName = "Nivel"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Nivel"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = nivelAppService.ObterTodos();
            return View(listaDados);
        }

        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var nivel = nivelAppService.ObterPorId(id);
            nivel.Familias.Clear();
            return Json(nivel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        [Route("Gravar")]
        public ActionResult Gravar(NivelViewModel nivel)
        {
            var gravarResult = nivelAppService.Gravar(nivel);
            object retorno;
            if (gravarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Registro Gravado com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(gravarResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}