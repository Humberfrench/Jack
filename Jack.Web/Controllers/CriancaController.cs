using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using WebGrease.Css.Extensions;

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
        private readonly IParametroServiceApp parametroAppService;
        private readonly ParametroViewModel parametros;
        #endregion

        #region Ctor

        public CriancaController(ICriancaServiceApp criancaAppService,
                                 IFamiliaServiceApp familiaAppService,
                                 IStatusCriancaServiceApp statusAppService,
                                 IParametroServiceApp parametroAppService,
                                 IKitServiceApp kitAppService)
        {
            this.criancaAppService = criancaAppService;
            this.familiaAppService = familiaAppService;
            this.statusAppService = statusAppService;
            this.kitAppService = kitAppService;
            this.parametroAppService = parametroAppService;
            parametros = parametroAppService.Obter();
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
            ViewBag.PercentualCriancas = 0;

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
            ViewBag.PercentualCriancas = 0;
            ViewBag.PermiteExcedente = "";
            ViewBag.Consistente = "";
            ViewBag.Sacolinha = "";
            ViewBag.PresencaJustificada = "";
            ViewBag.FamiliaId = familia;

            var listaDados = criancaAppService.ObterCriancas(familia).OrderBy(c => c.Nome).ToList();
            var familiaDado = listaDados.FirstOrDefault() ;
            if (familiaDado != null)
            {

                ViewBag.Presencas = familiaDado.Familia.QuantidadePresencas;
                ViewBag.Criancas = familiaDado.Familia.QuantidadeCriancas;
                ViewBag.PermiteExcedente = familiaDado.Familia.PermiteExcedenteCriancas ? "checked=checked" : "";
                ViewBag.Consistente = familiaDado.Familia.PermiteExcedenteCriancas ? "checked=checked" : "";
                ViewBag.Sacolinha = familiaDado.Familia.Sacolinha ? "checked=checked" : "";
                ViewBag.PresencaJustificada = familiaDado.Familia.PresencaJustificada ? "checked=checked" : "";
                var percCriancas = ((double)familiaDado.Familia.QuantidadeCriancas / (double)parametros.NumeroMaximoCricancas) * 100;
                ViewBag.PercentualCriancas = string.Format("{0} %",percCriancas);
            }


            return View(listaDados);
        }

        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var crianca = criancaAppService.ObterPorId(id);

            //zerando listas, não preciso da informação para serializar e evitar erros de referencia circular.
            crianca.Status.Criancas.Clear();
            crianca.Kit.Criancas.Clear();
            crianca.Kit.Items.Clear();
            crianca.Familia.Criancas.Clear();
            crianca.Familia.Nivel = null;
            crianca.Familia.Status = null;
            crianca.Familia.Presencas.Clear();
            crianca.Familia.Representantes.Clear();
            crianca.Sacola = null;

            return Json(crianca, JsonRequestBehavior.AllowGet);
        }

        [Route("ValidaCrianca")]
        public ActionResult ValidaCrianca(CriancaValueViewModel criancaValue)
        {
            var crianca = criancaAppService.ValidaCrianca(criancaValue);

            crianca.Status.Criancas.Clear();
            crianca.Kit.Criancas.Clear();
            crianca.Kit.Items.Clear();
            crianca.Familia = null;
            crianca.Sacola = null;

            return Json(crianca, JsonRequestBehavior.AllowGet);
        }

        [Route("ObterVestimentaPadrao")]
        public ActionResult ObterVestimentaPadrao(int idade, string medidaIdade, string sexo, bool isCriancaGrande = false)
        {
            var crianca = criancaAppService.ObterVestimentaPadrao(idade,medidaIdade,sexo, isCriancaGrande);

            var retorno = new
            {
                calcado = crianca["calcado"],
                roupa = crianca["roupa"]
            };
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        [Route("Gravar")]
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

        [Route("Excluir")]
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

        [Route("Acerto/Vestimentas")]
        public ActionResult AcertoVestimentas()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Crianças",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Crianças", ActionName = "Index", ControllerName = "Crianca"},
                 new BreadCrumb {LinkText = "Acerto Vestimentas", ActionName = "AcertoVestimentas", ControllerName = "Crianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.FamiliaId = 0;
            ViewBag.Criancas = 0;

            var listaDados = new List<CriancaVestimentaViewModel>();
            return View(listaDados);
        }

        [Route("Acerto/Vestimentas/{familia}")]
        public ActionResult AcertoVestimentas(int familia)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Crianças",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Crianças", ActionName = "Index", ControllerName = "Crianca"},
                 new BreadCrumb {LinkText = "Acerto Vestimentas", ActionName = "AcertoVestimentas", ControllerName = "Crianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.FamiliaId = 0;

            ViewBag.FamiliaId = familia;

            var listaDados = criancaAppService.ObterDadosCriancaVestimentas(familia).ToList();
            ViewBag.Criancas = listaDados.Count;

            return View(listaDados);
        }

        [Route("Acerto/Vestimentas/Gravar")]
        public ActionResult GravarVestimentas(int crianca, int calcado, string roupa)
        {
            var gravarResult = criancaAppService.GravarVestimentas(crianca, calcado, roupa);
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
            var dados = familiaAppService.ObterTodos().OrderBy(c => c.Nome).ToList();
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