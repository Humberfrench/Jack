using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("TipoDeProblema")]
    public class TipoDeProblemaController : BaseController
    {

        #region Vars

        private readonly ITipoDeProblemaServiceApp tipoDeProblemaAppService;

        #endregion

        #region Ctor

        public TipoDeProblemaController(ITipoDeProblemaServiceApp tipoDeProblemaAppService)
        {
            this.tipoDeProblemaAppService = tipoDeProblemaAppService;
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
                 new BreadCrumb {LinkText = "Status Tratamento", ActionName = "Index", ControllerName = "TipoDeProblema"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "TipoDeProblema"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = tipoDeProblemaAppService.ObterTodos();
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
                 new BreadCrumb {LinkText = "Status Tratamento", ActionName = "Index", ControllerName = "TipoDeProblema"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "TipoDeProblema"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaDados = tipoDeProblemaAppService.Filtrar(nome);

            return View("Index", listaDados);
        }

        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var tipoDeProblema = tipoDeProblemaAppService.ObterPorId(id);
            tipoDeProblema.TratamentoTiposDeProblema.Clear();
            return Json(tipoDeProblema, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        [Route("Gravar")]
        public ActionResult Gravar(TipoDeProblemaViewModel tipoDeProblema)
        {
            var gravarResult = tipoDeProblemaAppService.Gravar(tipoDeProblema);
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
            var excluirResult = tipoDeProblemaAppService.Excluir(id);

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

