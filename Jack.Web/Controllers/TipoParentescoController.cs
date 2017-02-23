using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("TipoParentesco")]
    public class TipoParentescoController : BaseController
    {
        #region Vars

        private readonly ITipoParentescoServiceApp tipoParentescoAppService;

        #endregion

        #region Ctor

        public TipoParentescoController(ITipoParentescoServiceApp tipoParentescoAppService)
        {
            this.tipoParentescoAppService = tipoParentescoAppService;
        }

        #endregion

        #region Public Methods
        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Tipo de Parentesco",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Tipo de Parentesco", ActionName = "Index", ControllerName = "TipoParentesco"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "TipoParentesco"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = tipoParentescoAppService.ObterTodos();
            return View(listaDados);
        }

        [HttpGet]
        [Route("Filtrar/{nome?}")]
        public ActionResult Filtrar(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Tipo de Parentesco",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Tipo de Parentesco", ActionName = "Index", ControllerName = "TipoParentesco"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "TipoParentesco"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaDados = tipoParentescoAppService.Filtrar(nome);

            return View("Index", listaDados);
        }

        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var tipoParentesco = tipoParentescoAppService.ObterPorId(id);
            return Json(tipoParentesco, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        [Route("Gravar")]
        public ActionResult Gravar(TipoParentescoViewModel tipoParentesco)
        {
            var gravarResult = tipoParentescoAppService .Gravar(tipoParentesco);
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
            var excluirResult = tipoParentescoAppService.Excluir(id);

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