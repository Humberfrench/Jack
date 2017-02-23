using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Colaborador/Crianca")]
    public class ColaboradorCriancaController : BaseController
    {
        #region Vars

        private readonly ICriancaServiceApp criancaAppService;
        private readonly IFamiliaServiceApp familiaAppService;
        private readonly INivelServiceApp nivelAppService;
        private readonly IKitServiceApp kitAppService;
        private readonly ISacolaServiceApp sacolaAppService;
        private readonly IColaboradorServiceApp colaboradorAppService;
        private readonly IColaboradorCriancaServiceApp colaboradorCriancaAppService;

        #endregion

        #region Ctor

        public ColaboradorCriancaController(ICriancaServiceApp criancaAppService,
                                            IFamiliaServiceApp familiaAppService, 
                                            INivelServiceApp nivelAppService,
                                            IKitServiceApp kitAppService,
                                            ISacolaServiceApp sacolaAppService,
                                            IColaboradorServiceApp colaboradorAppService,
                                            IColaboradorCriancaServiceApp colaboradorCriancaAppService)
        {
            this.criancaAppService = criancaAppService;
            this.familiaAppService = familiaAppService;
            this.nivelAppService = nivelAppService;
            this.kitAppService = kitAppService;
            this.sacolaAppService = sacolaAppService;
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
                Titulo = "Crianças do Colaborador",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Colaborador", ActionName = "Index", ControllerName = "Colaborador"},
                 new BreadCrumb {LinkText = "Crianças do Colaborador", ActionName = "Index", ControllerName = "ColaboradorCrianca"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "ColaboradorCrianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion


            ViewBag.Colaborador = ObterColaboradorParaCombo();
            ViewBag.ColaboradorId = 0;
            ViewBag.Ano = DateTime.Now.Year;

            var listaDados = new List<ColaboradorCriancaViewModel>();
            return View(listaDados);
        }

        [Route("{id}/Ano/{ano}")]
        public ActionResult Index(int id, int ano)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Crianças do Colaborador",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Colaborador", ActionName = "Index", ControllerName = "Colaborador"},
                 new BreadCrumb {LinkText = "Crianças do Colaborador", ActionName = "Index", ControllerName = "ColaboradorCrianca"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "ColaboradorCrianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion


            ViewBag.Colaborador = ObterColaboradorParaCombo();
            ViewBag.ColaboradorId = id;
            ViewBag.Ano = ano;

            var listaDados = colaboradorCriancaAppService.Obter(id, ano).ToList();

            return View(listaDados);
        }

        [Route("Excluir")]
        [HttpPost]
        public ActionResult Excluir(int id)
        {
            var excluirResult = colaboradorCriancaAppService.Excluir(id);

            object retorno;
            if (excluirResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Sacola  Excluída com Sucesso",
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

        [Route("Devolver")]
        [HttpPost]
        public ActionResult Devolver(int id, int colaborador, int ano)
        {
            var devolverrResult = colaboradorCriancaAppService.DevolveuSacola(colaborador, id, ano);

            object retorno;
            if (devolverrResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Sacola devolvida com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(devolverrResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [Route("Adicionar")]
        public ActionResult Adicionar()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Adicionar Crianças ao Colaborador",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Colaborador", ActionName = "Index", ControllerName = "Colaborador"},
                 new BreadCrumb {LinkText = "Crianças do Colaborador", ActionName = "Index", ControllerName = "ColaboradorCrianca"},
                 new BreadCrumb {LinkText = "Adicionar Crianças ao Colaborador", ActionName = "Adicionar", ControllerName = "ColaboradorCrianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Colaborador = ObterColaboradorParaCombo();
            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.Kit = ObterKitParaCombo();
            ViewBag.Nivel = ObterNivelParaCombo();

            ViewBag.ColaboradorId = 0;
            ViewBag.FamiliaId = 0;
            ViewBag.KitId = 0;
            ViewBag.Nivelid = 0;
            ViewBag.Sexo = 0;
            ViewBag.Ano = 0;

            var dados = new List<SacolaViewModel>();
            return View(dados);
        }

        [Route("ListaSacolas")]
        public ActionResult ListaSacolas(int ano,
                                         bool? liberado,
                                         int nivel = 0,
                                         int familia = 0,
                                         string sexo = "",
                                         int kit = 0)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Adicionar Crianças ao Colaborador",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Colaborador", ActionName = "Index", ControllerName = "Colaborador"},
                 new BreadCrumb {LinkText = "Crianças do Colaborador", ActionName = "Index", ControllerName = "ColaboradorCrianca"},
                 new BreadCrumb {LinkText = "Adicionar Crianças ao Colaborador", ActionName = "Adicionar", ControllerName = "ColaboradorCrianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Colaborador = ObterColaboradorParaCombo();
            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.Kit = ObterKitParaCombo();
            ViewBag.Nivel = ObterNivelParaCombo();

            ViewBag.FamiliaId = familia;
            ViewBag.KitId = kit;
            ViewBag.Nivelid = nivel;
            ViewBag.Sexo = sexo;
            ViewBag.Ano = ano;

            var sacolas = sacolaAppService.ObterSacolasLivres(liberado, ano, nivel, familia, sexo, kit);
            return View(sacolas);
        }

        [Route("AdicionarSacola")]
        [HttpPost]
        public ActionResult AdicionarSacola(int colaborador, int crianca, int ano)
        {
            var gravarResult = colaboradorCriancaAppService.AdicionaColaboradorCrianca(colaborador,crianca, ano);
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


        [Route("AdicionarSacolas")]
        [HttpPost]
        public ActionResult AdicionarSacolas(int colaborador, string sacolas, int ano)
        {
            var gravarResult = colaboradorCriancaAppService.AdicionarSacolas(colaborador,sacolas, ano);
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


        private IList<NivelViewModel> ObterNivel()
        {
            var lista = nivelAppService.ObterTodos().ToList();
            return lista;
        }

        private SelectList ObterNivelParaCombo()
        {
            var dados = ObterNivel();
            dados.Insert(0, new NivelViewModel { Codigo = 0, Nome = "Todos Níveis" });
            var listaSelect = new SelectList(dados, "Codigo", "Nome");

            return listaSelect;
        }


        private IList<KitViewModel> ObterKit()
        {
            var dados = kitAppService.ObterTodos().ToList();
            return dados;
        }

        private SelectList ObterKitParaCombo()
        {
            var dados = ObterKit();
            dados.Insert(0, new KitViewModel { Codigo = 0, Descricao = "Todos Kits" });
            var dadosSelect = new SelectList(dados, "Codigo", "Descricao");

            return dadosSelect;
        }

        private IList<FamiliaViewModel> ObterFamilia()
        {
            var dados = sacolaAppService.ObterFamiliasSacola().OrderBy(c => c.Nome).ToList();
            return dados;
        }

        private SelectList ObterFamiliaParaCombo()
        {
            var dados = ObterFamilia();
            dados.Insert(0, new FamiliaViewModel { Codigo = 0, Nome = "Todas Famílias" });
            var dadosSelect = new SelectList(dados, "Codigo", "Nome");

            return dadosSelect;
        }


        #endregion

    }
}