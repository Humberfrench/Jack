using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Presenca")]
    public class PresencaController : BaseController
    {
        #region Vars

        private readonly IPresencaServiceApp presencaAppService;
        private readonly IFamiliaServiceApp familiaAppService;
        private readonly IParametroServiceApp parametroAppService;
        private readonly IReuniaoServiceApp reuniaoAppService;
        private readonly ParametroViewModel parametros;

        #endregion

        #region Ctor

        public PresencaController(IPresencaServiceApp presencaAppService,
                                  IFamiliaServiceApp familiaAppService,
                                  IReuniaoServiceApp reuniaoAppService,
                                  IParametroServiceApp parametroAppService)
        {
            this.presencaAppService = presencaAppService;
            this.familiaAppService = familiaAppService;
            this.reuniaoAppService = reuniaoAppService;
            this.parametroAppService = parametroAppService;
            parametros = parametroAppService.Obter();
        }

        #endregion

        #region Métodos Públicos
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("ListaFamilias")]
        public ActionResult ListaFamilias(int reuniao, string letra)
        {
            List<FamiliaViewModel> familias;

            if (letra == "0")
            {
                familias = presencaAppService.ObterFamiliasDisponiveis(reuniao).ToList();
            }
            else
            {
                familias = presencaAppService.ObterFamiliasDisponiveis(reuniao, letra).ToList();
            }

            return View("ListaFamilias", familias);
        }

        [Route("ObterReunioes")]
        public ActionResult ObterReunioes(int ano)
        {
            var reunioes = reuniaoAppService.ObterReunioesNoAno(ano);
            
            reunioes.ToList().ForEach(r => r.FamiliaPresenca = null);
            return Json(reunioes, JsonRequestBehavior.AllowGet);
        }

        [Route("Familias")]
        [HttpPost]
        public ActionResult Gravar(int familia, int reuniao)
        {
            var gravarResult = presencaAppService.Gravar(reuniao, familia);
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

        [Route("Familias")]
        public ActionResult ListaPresenca()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Lista Presenca",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Lista Presenca", ActionName = "ListaPresenca", ControllerName = "Presenca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.PercentualCriancas = 0;
            ViewBag.Criancas = 0;
            ViewBag.PercentualReunioes = 0;
            ViewBag.Reunioes = 0;
            ViewBag.Presencas = 0;
            ViewBag.FamiliaId = 0;
            ViewBag.AnoPresenca = 0;
            var presencas = new List<PresencaViewModel>();
            return View(presencas);
        }

        [Route("Familias/{id}/Ano/{ano}")]
        public ActionResult ListaPresenca(int id, int ano)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Lista Presenca",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Lista Presenca", ActionName = "ListaPresenca", ControllerName = "Presenca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.FamiliaId = id;
            ViewBag.AnoPresenca = ano;
            ViewBag.PercentualCriancas = 0;
            ViewBag.Criancas = 0;
            ViewBag.PercentualReunioes = 0;
            ViewBag.Reunioes = 0;
            ViewBag.Presencas = 0;

            var familiaDado = familiaAppService.ObterPorId(id);
            var presencas = new List<PresencaViewModel>();
            if (familiaDado != null)
            {
                int reunioes;
                if (ano == parametros.AnoCorrente)
                {
                    reunioes = reuniaoAppService.ObterReunioesNoAno().Where(r => r.Data <= DateTime.Now).ToList().Count;
                }
                else
                {
                    reunioes = reuniaoAppService.ObterReunioesNoAno(ano).ToList().Count;
                }
                presencas = familiaDado.Presencas.Where(p => p.Reuniao.AnoCorrente == ano).ToList();
                ViewBag.Criancas = familiaDado.QuantidadeCriancas;
                var percCriancas = ((double)familiaDado.QuantidadeCriancas / (double)parametros.NumeroMaximoCricancas) * 100;
                ViewBag.PercentualCriancas = percCriancas;
                var percReunioes = ((double)presencas.Count / (double)reunioes) * 100;
                ViewBag.PercentualReunioes = percReunioes;
                ViewBag.Reunioes = reunioes;
                ViewBag.Presencas = presencas.Count;

            }

            return View(presencas);
        }

        [Route("ObterDadosPresenca")]
        public ActionResult ObterDadosPresenca(int familia)
        {
            var presencasTotais = presencaAppService.ObterDadosPresenca(familia);

            var retorno = new
            {
                AnosPresenca = presencasTotais.Select(p => p.Item).ToArray(),
                ValoresPresenca = presencasTotais.Select(p => p.Valor).ToArray()
            };

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Métodos Privados

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