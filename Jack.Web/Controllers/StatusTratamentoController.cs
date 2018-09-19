using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Status/Tratamento")]
    public class StatusTratamentoController : BaseController
    {
        #region Vars

        private readonly IStatusTratamentoServiceApp statusTratamentoAppService;

        #endregion

        #region Ctor

        public StatusTratamentoController(IStatusTratamentoServiceApp statusTratamentoAppService)
        {
            this.statusTratamentoAppService = statusTratamentoAppService;
        }

        #endregion

        #region Public Methods
        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Status Tratamento",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Status Tratamento", ActionName = "Index", ControllerName = "StatusTratamento"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "StatusTratamento"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = statusTratamentoAppService.ObterTodos();
            return View(listaDados);
        }

        [HttpGet]
        [Route("Filtrar/{nome?}")]
        public ActionResult Filtrar(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Status Tratamento",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Status Tratamento", ActionName = "Index", ControllerName = "StatusTratamento"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "StatusTratamento"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaDados = statusTratamentoAppService.Filtrar(nome);

            return View("Index", listaDados);
        }

        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var statusTratamento = statusTratamentoAppService.ObterPorId(id);
            statusTratamento.Tratamento.Clear();
            return Json(statusTratamento, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        [Route("Gravar")]
        public ActionResult Gravar(StatusTratamentoViewModel statusTratamento)
        {
            var gravarResult = statusTratamentoAppService.Gravar(statusTratamento);
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
            var excluirResult = statusTratamentoAppService.Excluir(id);

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