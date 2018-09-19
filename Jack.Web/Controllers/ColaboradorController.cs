using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Colaborador")]
    public class ColaboradorController : BaseController
    {
        #region Vars

        private readonly IColaboradorServiceApp colaboradorAppService;
        private readonly IColaboradorCriancaServiceApp colaboradorCriancaAppService;
        #endregion

        #region Ctor

        public ColaboradorController(IColaboradorServiceApp colaboradorAppService,
                                     IColaboradorCriancaServiceApp colaboradorCriancaAppService)
        {
            this.colaboradorAppService = colaboradorAppService;
            this.colaboradorCriancaAppService = colaboradorCriancaAppService;
        }

        #endregion


        #region Public Methods

        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Colaborador",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Colaborador", ActionName = "Index", ControllerName = "Colaborador"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Colaborador"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = colaboradorAppService.ObterTodos();
            return View(listaDados);
        }


        [HttpGet]
        [Route("Filtrar/{nome?}")]
        public ActionResult Filtrar(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Colaborador",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Colaborador", ActionName = "Index", ControllerName = "Colaborador"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "Colaborador"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            var listaDados = colaboradorAppService.Filtrar(nome);

            return View("Index", listaDados);
        }

        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var colaborador = colaboradorAppService.ObterPorId(id);
            colaborador.Criancas.Clear();
            return Json(colaborador, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        [Route("Gravar")]
        public ActionResult Gravar(ColaboradorViewModel tipoItem)
        {
            var gravarResult = colaboradorAppService.Gravar(tipoItem);
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
            var excluirResult = colaboradorAppService.Excluir(id);

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

        [Route("Pesquisa/Criancas")]
        public ActionResult PesquisaCriancas()
        {

            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Colaborador",
                BreadCrumbs = new List<BreadCrumb>
                {
                    new BreadCrumb {LinkText = "Colaborador", ActionName = "Index", ControllerName = "Colaborador"},
                    new BreadCrumb {LinkText = "Pesquisa Crianças", ActionName = "PesquisaCriancas", ControllerName = "Colaborador"}
                }
            };

            #endregion
            var listaDados = new List<ColaboradorCriancaViewModel>();
            return View("Criancas", listaDados);
        }

        [Route("Pesquisa/Criancas/{colaborador}/{ano}")]
        public ActionResult PesquisaCriancas(int colaborador, int ano)
        {

            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Colaborador",
                BreadCrumbs = new List<BreadCrumb>
                {
                    new BreadCrumb {LinkText = "Colaborador", ActionName = "Index", ControllerName = "Colaborador"},
                    new BreadCrumb {LinkText = "Pesquisa Crianças", ActionName = "PesquisaCriancas", ControllerName = "Colaborador"}
                }
            };

            #endregion
            var listaDados = colaboradorAppService.ObterSacolasColaborador(colaborador, ano);
            return View("Criancas", listaDados);
        }

        #endregion

        #region Private Methods
        private IList<ColaboradorViewModel> ObterColaborador()
        {
            var dados = colaboradorAppService.ObterTodos().OrderBy(c => c.Nome).ToList();
            return dados;
        }

        private SelectList ObterColaboradorParaCombo()
        {
            var dados = ObterColaborador();
            dados.Insert(0, new ColaboradorViewModel { Codigo = 0, Nome = "Selecione Colaborador" });
            var dadosSelect = new SelectList(dados, "Codigo", "Nome");

            return dadosSelect;
        }

        #endregion

    }
}