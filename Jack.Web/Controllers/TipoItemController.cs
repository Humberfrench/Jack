using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;

namespace Jack.Web.Controllers
{
    [RoutePrefix("TipoItem")]
    public class TipoItemController : BaseController
    {
        #region Vars

        private readonly ITipoItemServiceApp tipoItemAppService;

        #endregion

        #region Ctor

        public TipoItemController(ITipoItemServiceApp tipoItemAppService)
        {
            this.tipoItemAppService = tipoItemAppService;
        }

        #endregion

        #region Public Methods
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Tipo de Item",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Tipo de Item", ActionName = "Index", ControllerName = "TipoItem"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "TipoItem"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = tipoItemAppService.ObterTodos();
            return View(listaDados);
        }

        [HttpGet]
        [Route("Filtrar/{nome?}")]
        public ActionResult Filtrar(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Tipo de Item",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Tipo de Item", ActionName = "Index", ControllerName = "TipoItem"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "TipoItem"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaDados = tipoItemAppService.Filtrar(nome);

            return View("Index", listaDados);
        }

        public ActionResult Edit(int id)
        {
            var grupo = tipoItemAppService.ObterPorId(id);
            return Json(grupo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Gravar(TipoItemViewModel tipoItem)
        {
            var gravarResult = tipoItemAppService .Gravar(tipoItem);
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

        public ActionResult Excluir(int id)
        {
            var excluirResult = tipoItemAppService.Excluir(id);

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