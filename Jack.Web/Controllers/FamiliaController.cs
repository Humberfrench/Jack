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
   [RoutePrefix("Familia")]
   public class FamiliaController : BaseController
    {
        #region Vars

        private readonly IFamiliaServiceApp familiaAppService;
        private readonly IStatusFamiliaServiceApp statusAppService;
        private readonly INivelServiceApp nivelAppService;

        #endregion

        #region Ctor

        public FamiliaController(IFamiliaServiceApp familiaAppService,
                                 IStatusFamiliaServiceApp statusAppService,
                                 INivelServiceApp nivelAppService)
        {
            this.familiaAppService = familiaAppService;
            this.statusAppService = statusAppService;
            this.nivelAppService = nivelAppService;
        }

        #endregion

        #region Public Methods

        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Família",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Família", ActionName = "Index", ControllerName = "Familia"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Familia"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterStatusParaCombo();
            ViewBag.Nivel = ObterNivelParaCombo();

            var listaDados = familiaAppService.ObterTodos();
            return View(listaDados);
        }

        [HttpGet]
        [Route("Filtrar/{nome?}")]
        public ActionResult Filtrar(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Família",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Família", ActionName = "Index", ControllerName = "Familia"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "Familia"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterStatusParaCombo();
            ViewBag.Nivel = ObterNivelParaCombo();

            var listaDados = familiaAppService.Filtrar(nome);
            return View("Index", listaDados);
        }

        public ActionResult Edit(int id)
        {
            var familia = familiaAppService.ObterPorId(id);

            //zerando listas, não preciso da informação para serializar e evitar erros de referencia circular.
            familia.Criancas.Clear();
            familia.Representantes.Clear();
            familia.Sacolas.Clear();
            familia.Presencas.Clear();
            familia.Status.Familias.Clear();
            familia.Nivel.Familias.Clear();

            return Json(familia, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Gravar(FamiliaViewModel familia)
        {
            var gravarResult = familiaAppService .Gravar(familia);
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
            var excluirResult = familiaAppService.Excluir(id);

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

        public ActionResult ObterRepresentantes(int codigo)
        {
            var familia = familiaAppService.ObterPorId(codigo);
            return View("Representantes",familia.Representantes);
        }

        public ActionResult ObterCriancas(int codigo)
        {
            var familia = familiaAppService.ObterPorId(codigo);
            return View("Criancas", familia.Criancas);
        }

        public ActionResult ObterPresencas(int codigo)
        {
            var familia = familiaAppService.ObterPorId(codigo);
            return View("Presencas", familia.Presencas.Where(p => p.Reuniao.AnoCorrente == DateTime.Now.Year).ToList());
        }

        #endregion


        #region Métodos Privados

        private IList<StatusFamiliaViewModel> ObterStatus()
        {
            var status = statusAppService.ObterTodos().ToList();
            return status;
        }

        private SelectList ObterStatusParaCombo()
        {
            var status = ObterStatus();
            var statusSelect = new SelectList(status, "Codigo", "Descricao");

            return statusSelect;
        }

        private IList<NivelViewModel> ObterNivel()
        {
            var nivel = nivelAppService.ObterTodos().ToList();
            return nivel;
        }

        private SelectList ObterNivelParaCombo()
        {
            var nivel = ObterNivel();
            var nivelSelect = new SelectList(nivel, "Codigo", "Nome");

            return nivelSelect;
        }

        #endregion
    }
}