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
    [RoutePrefix("Kit")]
    public class KitController : BaseController
    {
        #region Vars

        private readonly IKitServiceApp kitAppService;

        #endregion

        #region Ctor

        public KitController(IKitServiceApp kitAppService)
        {
            this.kitAppService = kitAppService;
        }

        #endregion

        #region Public Methods
        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Kits",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Kits", ActionName = "Index", ControllerName = "Kit"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Kit"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = kitAppService.ObterTodos();
            return View(listaDados);
        }

        [HttpGet]
        [Route("Filtrar/{nome?}")]
        public ActionResult Filtrar(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Kits",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Kits", ActionName = "Index", ControllerName = "Kit"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "Kit"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaDados = kitAppService.Filtrar(nome);

            return View("Index", listaDados);
        }

        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var kit = kitAppService.ObterPorId(id);
            kit.Criancas.Clear();
            kit.Items.Clear();
            return Json(kit, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        [Route("Gravar")]
        public ActionResult Gravar(KitViewModel kit)
        {
            var gravarResult = kitAppService .Gravar(kit);
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

        [Route("Excluir")]
        public ActionResult Excluir(int id)
        {
            var excluirResult = kitAppService.Excluir(id);

            object retorno;
            if (excluirResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Registro Excluído com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(excluirResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}