using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using Jack.DomainValidator;

namespace Jack.Web.Controllers
{
   [RoutePrefix("Familia")]
   public class FamiliaController : BaseController
    {
        #region Vars

        private readonly IFamiliaServiceApp familiaAppService;
        private readonly INivelServiceApp nivelAppService;
        private readonly IStatusFamiliaServiceApp statusAppService;
        private readonly IReuniaoServiceApp reuniaoAppService;

        #endregion

        #region Ctor

        public FamiliaController(IFamiliaServiceApp familiaAppService,
                                 IStatusFamiliaServiceApp statusAppService,
                                 INivelServiceApp nivelAppService,
                                 IReuniaoServiceApp reuniaoAppService)
        {
            this.familiaAppService = familiaAppService;
            this.statusAppService = statusAppService;
            this.nivelAppService = nivelAppService;
            this.reuniaoAppService = reuniaoAppService;
        }

        #endregion

        #region Public Methods

        [Route("")]
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
            ViewBag.Reuniao = ObterReuniaoParaCombo();

            var listaDados = familiaAppService.ObterTodos().OrderBy(c => c.Nome);
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
            ViewBag.Reuniao = ObterReuniaoParaCombo();

            var listaDados = familiaAppService.Filtrar(nome);
            return View("Index", listaDados);
        }

        [Route("Edit")]
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
        [Route("Gravar")]
        public ActionResult Gravar(FamiliaViewModel familia, int reuniao)
        {
            ValidationResult gravarResult;

            if (reuniao==0)
            {
                gravarResult = familiaAppService.Gravar(familia);
            }
            else
            {
                gravarResult = familiaAppService.Gravar(familia, reuniao);
            }

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

        [Route("Processar")]
        public ActionResult Processar(int id)
        {
            var processarResult = familiaAppService.AtualizarFamilia(id);

            object retorno;
            if (processarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Família Atualizada com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(processarResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [Route("ObterRepresentantes")]
        public ActionResult ObterRepresentantes(int codigo)
        {
            var familia = familiaAppService.ObterPorId(codigo);
            return View("Representantes",familia.Representantes);
        }

        [Route("ObterCriancas")]
        public ActionResult ObterCriancas(int codigo)
        {
            var familia = familiaAppService.ObterPorId(codigo);
            return View("Criancas", familia.Criancas);
        }

        [Route("ObterPresencas")]
        public ActionResult ObterPresencas(int codigo)
        {
            var familia = familiaAppService.ObterPorId(codigo);
            return View("Presencas", familia.Presencas.Where(p => p.Reuniao.AnoCorrente == DateTime.Now.Year).ToList());
        }

        #endregion


        #region Métodos Privados

        private IList<ReuniaoViewModel> ObterReuniao()
        {
            var lista = reuniaoAppService.ObterReunioesNoAno().ToList();
            return lista;
        }

        private SelectList ObterReuniaoParaCombo()
        {
            var lista = ObterReuniao();
            var listaSelect = new SelectList(lista, "Codigo", "DataTexto");

            return listaSelect;
        }
        private IList<StatusFamiliaViewModel> ObterStatus()
        {
            var lista = statusAppService.ObterTodos().ToList();
            return lista;
        }

        private SelectList ObterStatusParaCombo()
        {
            var lista = ObterStatus();
            var listaSelect = new SelectList(lista, "Codigo", "Descricao");

            return listaSelect;
        }

        private IList<NivelViewModel> ObterNivel()
        {
            var lista = nivelAppService.ObterTodos().ToList();
            return lista;
        }

        private SelectList ObterNivelParaCombo()
        {
            var lista = ObterNivel();
            var listaSelect = new SelectList(lista, "Codigo", "Nome");

            return listaSelect;
        }

        #endregion
    }
}