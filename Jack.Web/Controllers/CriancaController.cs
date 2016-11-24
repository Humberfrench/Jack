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
    [RoutePrefix("Crianca")]
    public class CriancaController : BaseController
    {
        #region Vars

        private readonly ICriancaServiceApp criancaAppService;
        private readonly IFamiliaServiceApp familiaAppService;
        private readonly IStatusCriancaServiceApp statusAppService;
        private readonly IKitServiceApp kitAppService;

        #endregion

        #region Ctor

        public CriancaController(ICriancaServiceApp criancaAppService,
                                 IFamiliaServiceApp familiaAppService, 
                                 IStatusCriancaServiceApp statusAppService,
                                 IKitServiceApp kitAppService)
        {
            this.criancaAppService = criancaAppService;
            this.familiaAppService = familiaAppService;
            this.statusAppService = statusAppService;
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
                Titulo = "Crianças",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Crianças", ActionName = "Index", ControllerName = "Crianca"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Crianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterStatusParaCombo();
            ViewBag.Kit = ObterKitParaCombo();
            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.FamiliaId = 0;

            var listaDados = new List<CriancaViewModel>();
            return View(listaDados);
        }

        [Route("{familia}")]
        public ActionResult Index(int familia)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Crianças",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Crianças", ActionName = "Index", ControllerName = "Crianca"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Crianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterStatusParaCombo();
            ViewBag.Kit = ObterKitParaCombo();
            ViewBag.Familia = ObterFamiliaParaCombo();

            ViewBag.Presencas = 0;
            ViewBag.Criancas = 0;
            ViewBag.PermiteExcedente = "";
            ViewBag.Consistente = "";
            ViewBag.Sacolinha = "";
            ViewBag.PresencaJustificada = "";
            ViewBag.FamiliaId = familia;

            var listaDados = criancaAppService.ObterCriancas(familia).ToList();
            var familiaDado = listaDados.FirstOrDefault() ;
            if (familiaDado != null)
            {

                ViewBag.Presencas = familiaDado.Familia.QuantidadePresencas;
                ViewBag.Criancas = familiaDado.Familia.QuantidadeCriancas;
                ViewBag.PermiteExcedente = familiaDado.Familia.PermiteExcedente ? "checked=checked" : "";
                ViewBag.Consistente = familiaDado.Familia.PermiteExcedente ? "checked=checked" : "";
                ViewBag.Sacolinha = familiaDado.Familia.Sacolinha ? "checked=checked" : "";
                ViewBag.PresencaJustificada = familiaDado.Familia.PresencaJustificada ? "checked=checked" : "";
            }
            return View(listaDados);
        }
        public ActionResult Edit(int id)
        {
            var crianca = criancaAppService.ObterPorId(id);

            //zerando listas, não preciso da informação para serializar e evitar erros de referencia circular.
            crianca.Status.Criancas.Clear();
            crianca.Kit.Criancas.Clear();
            crianca.Familia.Criancas.Clear();
            crianca.Sacola = null;

            return Json(crianca, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Gravar(CriancaViewModel crianca)
        {
            var gravarResult = criancaAppService .Gravar(crianca);
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
            var excluirResult = criancaAppService.Excluir(id);

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


        #region Métodos Privados

        private IList<StatusCriancaViewModel> ObterStatus()
        {
            var dados = statusAppService.ObterTodos().ToList();
            return dados;
        }

        private SelectList ObterStatusParaCombo()
        {
            var dados = ObterStatus();
            var dadosSelect = new SelectList(dados, "Codigo", "Descricao");

            return dadosSelect;
        }

        private IList<KitViewModel> ObterKit()
        {
            var dados = kitAppService.ObterTodos().ToList();
            return dados;
        }

        private SelectList ObterKitParaCombo()
        {
            var dados = ObterKit();
            var dadosSelect = new SelectList(dados, "Codigo", "Descricao");

            return dadosSelect;
        }

        private IList<FamiliaViewModel> ObterFamilia()
        {
            var dados = familiaAppService.ObterTodos().ToList();
            return dados;
        }

        private SelectList ObterFamiliaParaCombo()
        {
            var dados = ObterFamilia();
            var dadosSelect = new SelectList(dados, "Codigo", "Nome");

            return dadosSelect;
        }

        #endregion
    }
}