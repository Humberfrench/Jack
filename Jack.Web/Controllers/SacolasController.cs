﻿using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Sacolas")]
    public class SacolasController : BaseController
    {
        #region Vars

        private readonly ISacolaServiceApp sacolaAppService;
        private readonly INivelServiceApp nivelAppService;
        private readonly ICriancaServiceApp criancaAppService;
        private readonly IFamiliaServiceApp familiaAppService;

        #endregion

        #region Ctor

        public SacolasController(ICriancaServiceApp criancaAppService,
                                 IFamiliaServiceApp familiaAppService,
                                 ISacolaServiceApp sacolaAppService,
                                 INivelServiceApp nivelAppService)
        {
            this.sacolaAppService = sacolaAppService;
            this.nivelAppService = nivelAppService;
            this.criancaAppService = criancaAppService;
            this.familiaAppService = familiaAppService;
        }

        #endregion

        #region Public Methods
        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Consulta de Sacolas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Consulta de Sacolas", ActionName = "Index", ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Sacolas"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Nivel = ObterNivelParaCombo();
            ViewBag.NivelId = 0;
            ViewBag.LiberadoValue = 0;
            var listaDados = sacolaAppService.ObterTodos();
            return View(listaDados);
        }

        [Route("Nivel/{nivel}/Liberado/{liberado}")]
        public ActionResult Index(int nivel, int liberado)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Consulta de Sacolas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Consulta de Sacolas", ActionName = "Index", ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Sacolas"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Nivel = ObterNivelParaCombo();
            ViewBag.NivelId = nivel;
            ViewBag.LiberadoValue = liberado;
            var listaDados = sacolaAppService.ObterTodosPorNivel(nivel, liberado);
            return View(listaDados);
        }

        [Route("Livres")]
        public ActionResult SacolasLivres()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Consulta de Sacolas Livres",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Consulta de Sacolas Livres", ActionName = "Index", ControllerName = "Sacolas Livres"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Nivel = ObterNivelParaCombo();
            ViewBag.NivelId = 0;
            ViewBag.LiberadoValue = 0;
            var listaDados = sacolaAppService.ObterSacolasLivres();
            return View(listaDados);
        }

        [Route("Livres/Nivel/{nivel}/Liberado/{liberado}")]
        public ActionResult SacolasLivres(int nivel, int liberado)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Consulta de Sacolas Livres",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Consulta de Sacolas Livres", ActionName = "Index", ControllerName = "Sacolas Livres"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Nivel = ObterNivelParaCombo();
            ViewBag.NivelId = nivel;
            ViewBag.LiberadoValue = liberado;
            var listaDados = sacolaAppService.ObterSacolasLivres(nivel, liberado);
            return View(listaDados);
        }

        [Route("Liberar")]
        public ActionResult Liberar(int id)
        {
            var gravarResult = sacolaAppService.Liberar(id);
            object retorno;
            if (gravarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Sacola Liberada com Sucesso",
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

        [Route("AdicionarCrianca")]
        public ActionResult AdicionarCrianca()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Adicionar Crianca a Sacola",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Adicionar Crianca a Sacola", ActionName = "Index", ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Crianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.FamiliaId = 0;
            ViewBag.Nivel = "";

            var listaDados = new List<CriancaViewModel>();
            return View(listaDados);
        }

        [Route("AdicionarCrianca/{id}")]
        public ActionResult AdicionarCrianca(int id)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Adicionar Crianca a Sacola",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Adicionar Crianca a Sacola", ActionName = "Index", ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Crianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;

            #endregion

            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.Nivel = "";
            ViewBag.FamiliaId = id;

            var listaDados = criancaAppService.ObterCriancasSacola(id).OrderBy(c => c.Nome).ToList();
            var familiaDado = listaDados.FirstOrDefault();
            if (familiaDado != null)
            {
                ViewBag.Nivel = familiaDado.Familia.Nivel.Nome;
            }

            return View(listaDados);
        }

        public ActionResult GerarSacolas()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Gerar Sacolas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Gerar Sacolas", ActionName = "Index", ControllerName = "Sacolas"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Ano = 0;

            var listaDados = new List<SacolaViewModel>();
            return View(listaDados);

        }
        public ActionResult GerarSacolas(int ano)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Gerar Sacolas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Gerar Sacolas", ActionName = "Index", ControllerName = "Sacolas"}
                }
            };


            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Ano = ano;

            var retorno = sacolaAppService.ProcessarSacolas(ano);

            return View(retorno);
        }

        [Route("AdicionarCriancaNaSacola")]
        [HttpPost]
        public ActionResult AdicionarCriancaNaSacola(int id)
        {
            var gravarResult = sacolaAppService.AddCrianca(id);
            object retorno;
            if (gravarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Criança Adicionada na Sacola com Sucesso",
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


        private IList<NivelViewModel> ObterNivel()
        {
            var lista = nivelAppService.ObterTodos().ToList();
            return lista;
        }

        private SelectList ObterNivelParaCombo()
        {
            var lista = ObterNivel();
            var listaSelect = new SelectList(lista, "Codigo", "Descricao");

            return listaSelect;
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