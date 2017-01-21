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
    [RoutePrefix("Status/Crianca")]
    public class StatusCriancaController : BaseController
    {
        #region Vars

        private readonly IStatusCriancaServiceApp statusCriancaAppService;

        #endregion

        #region Ctor

        public StatusCriancaController(IStatusCriancaServiceApp statusCriancaAppService)
        {
            this.statusCriancaAppService = statusCriancaAppService;
        }

        #endregion

        #region Public Methods
        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Status Criança",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Status Criança", ActionName = "Index", ControllerName = "StatusCrianca"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "StatusCrianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = statusCriancaAppService.ObterTodos();
            return View(listaDados);
        }

        [HttpGet]
        [Route("Filtrar/{nome?}")]
        public ActionResult Filtrar(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Status Criança",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Status Criança", ActionName = "Index", ControllerName = "StatusCrianca"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "StatusCrianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaDados = statusCriancaAppService.Filtrar(nome);

            return View("Index", listaDados);
        }

        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var statusCrianca = statusCriancaAppService.ObterPorId(id);
            statusCrianca.Criancas.Clear();
            return Json(statusCrianca, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        [Route("Gravar")]
        public ActionResult Gravar(StatusCriancaViewModel statusCrianca)
        {
            var gravarResult = statusCriancaAppService .Gravar(statusCrianca);
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
            var excluirResult = statusCriancaAppService.Excluir(id);

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