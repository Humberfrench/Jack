using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{   [RoutePrefix("Parametros")]
    public class ParametroController : Controller
    {
        #region Vars

        private readonly IParametroServiceApp parameterAppService;

        #endregion

        #region Ctor

        public ParametroController(IParametroServiceApp parameterAppService)
        {
            this.parameterAppService = parameterAppService;
        }

        #endregion

        #region Public Methods

        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Parâmetros",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Parâmetros", ActionName = "Index", ControllerName = "Parametros"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var parametro = parameterAppService.Obter();
            return View(parametro);
        }

        [Route("Obter")]
        public ActionResult Obter()
        {
            var parametro = parameterAppService.Obter();
            return Json(parametro, JsonRequestBehavior.AllowGet);
        }

        [Route("Gravar")]
        public ActionResult Gravar(ParametroViewModel parametros)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Parâmetros",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Parâmetros", ActionName = "Index", ControllerName = "Parametros"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var gravarResult = parameterAppService.Gravar(parametros);
            Aviso aviso;

            if (gravarResult.IsValid == false)
            {
                aviso = new Aviso
                {
                    TipoMensagem = Aviso.Tipo.Erro,
                    TituloMensagem = "Problemas com o formulário:"
                };

                gravarResult.Erros.ToList().ForEach(x => aviso.Mensagens.Add(x.Messagem));

                TempData["Aviso"] = aviso;
                return View("Index");
            }

            aviso = new Aviso
            {
                TipoMensagem = Aviso.Tipo.Erro,
                TituloMensagem = "Suvesso:"
            };

            aviso.Mensagens.Add("Dados Atualizados com Sucesso!");

            TempData["Aviso"] = aviso;

            return View("Index",parametros);
        }

        #endregion
    }
}