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
    [RoutePrefix("Representante")]
    public class RepresentanteController : BaseController
    {
        #region Vars

        private readonly IFamiliaServiceApp familiaAppService;
        private readonly IRepresentanteServiceApp representanteAppService;
        private readonly IParametroServiceApp parametroAppService;
        private readonly ITipoParentescoServiceApp tipoParentescoAppService;
        private readonly ParametroViewModel parametros;

        #endregion

        #region Ctor

        public RepresentanteController(IFamiliaServiceApp familiaAppService,
                                       IRepresentanteServiceApp representanteAppService,
                                       IParametroServiceApp parametroAppService,
                                       ITipoParentescoServiceApp tipoParentescoAppService)
        {
            this.familiaAppService = familiaAppService;
            this.representanteAppService = representanteAppService;
            this.parametroAppService = parametroAppService;
            this.tipoParentescoAppService = tipoParentescoAppService;
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
                Titulo = "Representantes",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Familias", ActionName = "Index", ControllerName = "Familia"},
                 new BreadCrumb {LinkText = "Representantes", ActionName = "Index", ControllerName = "Representante"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.TipoParentesco = ObterTipoParentescoParaCombo();
            ViewBag.FamiliaId = 0;
            ViewBag.PercentualCriancas = 0;

            var listaDados = new List<RepresentanteViewModel>();
            return View(listaDados);
        }

        [Route("{familia}")]
        public ActionResult Index(int familia)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Representantes",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Familias", ActionName = "Index", ControllerName = "Familia"},
                 new BreadCrumb {LinkText = "Representantes", ActionName = "Index", ControllerName = "Representante"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.TipoParentesco = ObterTipoParentescoParaCombo();
            ViewBag.Presencas = 0;
            ViewBag.Criancas = 0;
            ViewBag.PercentualCriancas = 0;
            ViewBag.PermiteExcedente = "";
            ViewBag.Consistente = "";
            ViewBag.Sacolinha = "";
            ViewBag.PresencaJustificada = "";
            ViewBag.FamiliaId = familia;

            var listaDados = new List<RepresentanteViewModel>();
            var familiaDado = familiaAppService.ObterPorId(familia);
            if (familiaDado != null)
            {
                listaDados = familiaDado.Representantes.ToList();
                ViewBag.Presencas = familiaDado.QuantidadePresencas;
                ViewBag.Criancas = familiaDado.QuantidadeCriancas;
                ViewBag.PermiteExcedente = familiaDado.PermiteExcedenteCriancas ? "checked=checked" : "";
                ViewBag.Consistente = familiaDado.PermiteExcedenteCriancas ? "checked=checked" : "";
                ViewBag.Sacolinha = familiaDado.Sacolinha ? "checked=checked" : "";
                ViewBag.PresencaJustificada = familiaDado.PresencaJustificada ? "checked=checked" : "";
                var percCriancas = ((double)familiaDado.QuantidadeCriancas / (double)parametros.NumeroMaximoCricancas) * 100;
                ViewBag.PercentualCriancas = string.Format("{0} %", percCriancas);
            }


            return View(listaDados);
        }

        [Route("ListaRepresentantes")]
        public ActionResult ListaRepresentantes(int id)
        {
            var lista = representanteAppService.ObterFamilias(id);

            return View(lista);
        }

        [Route("Ativar")]
        [HttpPost]
        public ActionResult Ativar(int id)
        {
            {
                var gravarResult = representanteAppService.Ativar(id);
                object retorno;
                if (gravarResult.IsValid)
                {
                    retorno = new
                    {
                        Mensagem = "Representante Ativado com Sucesso",
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
        }

        [Route("Desativar")]
        [HttpPost]
        public ActionResult Desativar(int id)
        {
            {
                var gravarResult = representanteAppService.Desativar(id);
                object retorno;
                if (gravarResult.IsValid)
                {
                    retorno = new
                    {
                        Mensagem = "Representante Desativado com Sucesso",
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
        }

        [HttpPost]
        [Route("Gravar")]
        public ActionResult Gravar(int familiaRepresentante, int familiaRepresentada, int tipoParentesco)
        {
            {
                var gravarResult = representanteAppService.Gravar(familiaRepresentante, familiaRepresentada, tipoParentesco);
                object retorno;
                if (gravarResult.IsValid)
                {
                    retorno = new
                    {
                        Mensagem = "Representante Gravado com Sucesso",
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
        }

        [HttpPost]
        [Route("GravarEdicao")]
        public ActionResult GravarEdicao(int codigo, int tipoParentesco, bool ativo)
        {
            {
                var gravarResult = representanteAppService.Gravar(codigo, tipoParentesco, ativo);
                object retorno;
                if (gravarResult.IsValid)
                {
                    retorno = new
                    {
                        Mensagem = "Representante Gravado com Sucesso",
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
        }

        [Route("Excluir")]
        [HttpPost]
        public ActionResult Excluir(int id)
        {
            {
                var gravarResult = representanteAppService.Excluir(id);
                object retorno;
                if (gravarResult.IsValid)
                {
                    retorno = new
                    {
                        Mensagem = "Representante Excluido com Sucesso",
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
        }

        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var representante = representanteAppService.ObterPorId(id);

            representante.FamiliaRepresentante.Criancas.Clear();
            representante.FamiliaRepresentante.Nivel.Familias.Clear();
            representante.FamiliaRepresentante.Status.Familias.Clear();
            representante.FamiliaRepresentante.Presencas.Clear();
            representante.FamiliaRepresentante.Representantes.Clear();
            representante.FamiliaRepresentante.Sacolas.Clear();

            representante.FamiliaRepresentada.Criancas.Clear();
            representante.FamiliaRepresentada.Nivel.Familias.Clear();
            representante.FamiliaRepresentada.Status.Familias.Clear();
            representante.FamiliaRepresentada.Presencas.Clear();
            representante.FamiliaRepresentada.Representantes.Clear();
            representante.FamiliaRepresentada.Sacolas.Clear();

            return Json(representante, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Métodos Privados

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

        private IList<TipoParentescoViewModel> ObterTipoParentesco()
        {
            var dados = tipoParentescoAppService.ObterTodos().ToList();
            return dados;
        }

        private SelectList ObterTipoParentescoParaCombo()
        {
            var dados = ObterTipoParentesco();
            var dadosSelect = new SelectList(dados, "Codigo", "Descricao");

            return dadosSelect;
        }

        #endregion

    }
}