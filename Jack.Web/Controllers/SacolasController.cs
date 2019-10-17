using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using System;
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
        private readonly IKitServiceApp kitAppService;
        private readonly IColaboradorServiceApp colaboradorAppService;
        private readonly IColaboradorCriancaServiceApp colaboradorCriancaAppService;

        #endregion

        #region Ctor

        public SacolasController(ICriancaServiceApp criancaAppService,
                                 IFamiliaServiceApp familiaAppService,
                                 ISacolaServiceApp sacolaAppService,
                                 INivelServiceApp nivelAppService,
                                 IKitServiceApp kitAppService,
                                 IColaboradorServiceApp colaboradorAppService,
                                 IColaboradorCriancaServiceApp colaboradorCriancaAppService)
        {
            this.sacolaAppService = sacolaAppService;
            this.nivelAppService = nivelAppService;
            this.criancaAppService = criancaAppService;
            this.familiaAppService = familiaAppService;
            this.kitAppService = kitAppService;
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
                Titulo = "Consulta de Sacolas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Consulta de Sacolas", ActionName = nameof(Index), ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Lista", ActionName = nameof(Index), ControllerName = "Sacolas"}
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
                 new BreadCrumb {LinkText = "Consulta de Sacolas", ActionName = nameof(Index), ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Lista", ActionName = nameof(Index), ControllerName = "Sacolas"}
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
                 new BreadCrumb {LinkText = "Lista", ActionName = nameof(Index), ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Consulta de Sacolas Livres", ActionName = nameof(Index), ControllerName = "Sacolas Livres"}
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
                 new BreadCrumb {LinkText = "Lista", ActionName = nameof(Index), ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Consulta de Sacolas Livres", ActionName = nameof(Index), ControllerName = "Sacolas Livres"}
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

        [Route(nameof(Liberar))]
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

        [Route(nameof(AdicionarCrianca))]
        public ActionResult AdicionarCrianca()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Adicionar Criança a Sacola",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Adicionar Criança a Sacola", ActionName = nameof(Index), ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Lista", ActionName = nameof(Index), ControllerName = "Crianca"}
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
                Titulo = "Adicionar Criança a Sacola",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Adicionar Criança a Sacola", ActionName = nameof(Index), ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Lista", ActionName = nameof(Index), ControllerName = "Crianca"}
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

        [Route(nameof(AdicionarFamilia))]
        public ActionResult AdicionarFamilia()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Adicionar Crianças de Uma Família a Sacola",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Adicionar Crianças de Uma Família a Sacola", ActionName = nameof(Index), ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Lista", ActionName = nameof(Index), ControllerName = "Crianca"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = sacolaAppService.ObterFamiliasDisponiveis();
            return View(listaDados.ToList());
        }

        [Route(nameof(GerarSacolas))]
        public ActionResult GerarSacolas()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Gerar Sacolas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Gerar Sacolas", ActionName = nameof(Index), ControllerName = "Sacolas"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Ano = 0;

            var listaDados = new List<SacolaViewModel>();
            return View(listaDados);

        }

        [Route("GerarSacolas/{ano}")]
        public ActionResult GerarSacolas(int ano)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Gerar Sacolas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Gerar Sacolas", ActionName = nameof(Index), ControllerName = "Sacolas"}
                }
            };


            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Ano = ano;

            var retorno = sacolaAppService.ProcessarSacolas(ano, false);
            var listaDados = new List<SacolaViewModel>();

            return View(listaDados);
        }

        [Route(nameof(AdicionarCriancaNaSacola))]
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

        [Route(nameof(Pesquisar))]
        public ActionResult Pesquisar()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Pesquisar de Sacolas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Lista", ActionName = nameof(Index), ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Pesquisa de Sacolas", ActionName = nameof(Pesquisar), ControllerName = "Sacolas Livres"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Nivel = ObterNivelParaCombo();
            ViewBag.Kit = ObterKitParaCombo();
            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.NivelNivelId = 0;
            ViewBag.KitId = 0;
            ViewBag.FamiliaId = 0;
            ViewBag.Ano = 0;

            var dados = new List<SacolaViewModel>();
            return View(dados);
        }

        [Route("Pesquisar/Nivel/{nivel}/Kit/{kit}")]
        public ActionResult PesquisarSacolas(int kit, int nivel)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Pesquisar de Sacolas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Lista", ActionName = nameof(Index), ControllerName = "Sacolas"},
                 new BreadCrumb {LinkText = "Pesquisa de Sacolas", ActionName = nameof(Pesquisar), ControllerName = "Sacolas Livres"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Nivel = ObterNivelParaCombo();
            ViewBag.Kit = ObterKitParaCombo();
            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.NivelNivelId = nivel;
            ViewBag.KitId = kit;
            ViewBag.FamiliaId = 0;

            var dados = sacolaAppService.PesquisarSacolas(kit, nivel);
            return View(nameof(Pesquisar), dados);
        }

        [Route("Pesquisar/Familia/{familia}/Nivel/{nivel}")]
        public ActionResult PesquisarSacolasFamilia(int familia, int nivel)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Pesquisar de Sacolas",
                BreadCrumbs = new List<BreadCrumb>
                {
                    new BreadCrumb {LinkText = "Lista", ActionName = nameof(Index), ControllerName = "Sacolas"},
                    new BreadCrumb {LinkText = "Pesquisa de Sacolas", ActionName = nameof(Pesquisar), ControllerName = "Sacolas Livres"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Nivel = ObterNivelParaCombo();
            ViewBag.Kit = ObterKitParaCombo();
            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.NivelNivelId = nivel;
            ViewBag.KitId = 0;
            ViewBag.FamiliaId = familia;

            var dados = sacolaAppService.PesquisarSacolas(familia);
            return View(nameof(Pesquisar), dados);
        }


        [HttpGet]
        [Route("Pesquisar/ObterFamilias/{nivel}")]
        public ActionResult ObterFamilias(int nivel)
        {
            var sacolas = sacolaAppService.ObterFamilias(nivel).ToList();

            return Json(sacolas, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        [Route("Pesquisar/AdicionarColaboradores/{sacola}")]
        public ActionResult AdicionarColaboradoresLista(int sacola)
        {
            var colaboradores = colaboradorAppService.ObterTodos();
            ViewBag.Sacola = sacola;
            return View(colaboradores);
        }

        [HttpPost]
        [Route("Pesquisar/AdicionarColaborador")]
        public ActionResult AdicionarColaborador(int colaborador, int sacola)
        {
            var colaboradorResult = colaboradorCriancaAppService.AdicionaColaboradorSacola(colaborador, sacola, DateTime.Now.Year);
            object retorno;
            if (colaboradorResult.IsValid)
            {
                retorno = new
                {
                    Messagem = "Colaborador Adicionado com sucesso",
                    Sucesso = true
                };
            }
            else
            {
                retorno = new
                {
                    colaboradorResult.Messagem,
                    Sucesso = true
                };

            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("Pesquisar/Print/{sacola}")]
        public ActionResult Print(int sacola)
        {
            var sacolaPrint = sacolaAppService.ObterPorId(sacola);
            ViewBag.Colaborador = "Não Associado";
            if (sacolaPrint != null)
            {
                var colaborador = colaboradorCriancaAppService.ObterColaborador(sacolaPrint.Crianca.Codigo, DateTime.Now.Year);
                if (colaborador != null)
                {
                    ViewBag.Colaborador = colaborador.Nome;
                }
            }
            return View(sacolaPrint);
        }

        [HttpGet]
        [Route("Pesquisar/Prints/{sacola}")]
        public ActionResult Prints(string sacola)
        {
            var sacolaPrint = sacolaAppService.ObterSacolaParaImpressao(sacola, DateTime.Now.Year);

            return View(sacolaPrint);
        }

        [HttpGet]
        [Route("Pesquisar/Prints/Unica/{sacola}")]
        public ActionResult PrintsUmAUm(string sacola)
        {
            var sacolaPrint = sacolaAppService.ObterSacolaParaImpressao(sacola, DateTime.Now.Year);

            return View(sacolaPrint);
        }

        [HttpGet]
        [Route("Update/QrCodes")]
        public ActionResult UpdateQrCodes()
        {
            sacolaAppService.AtualizarQrCodeSacolas();

            return View();
        }

        #endregion

        #region Métodos Privados

        private IList<NivelViewModel> ObterNivel()
        {
            var lista = nivelAppService.ObterTodos().ToList();
            var nivel = new NivelViewModel
            {
                Codigo = 0,
                Descricao = "Selecione Nivel"
            };
            lista.Insert(0, nivel);
            return lista;
        }

        private SelectList ObterNivelParaCombo()
        {
            var lista = ObterNivel().Where(n => n.Codigo < 6).ToList();
            var listaSelect = new SelectList(lista, "Codigo", "Nome");

            return listaSelect;
        }

        private IList<FamiliaViewModel> ObterFamilia()
        {
            var dados = familiaAppService.ObterTodos().OrderBy(c => c.Nome).ToList();
            var familia = new FamiliaViewModel
            {
                Codigo = 0,
                Nome = "Selecione Família"
            };
            dados.Insert(0, familia);
            return dados;
        }

        private SelectList ObterFamiliaParaCombo()
        {
            var dados = ObterFamilia();
            var dadosSelect = new SelectList(dados, "Codigo", "Nome");

            return dadosSelect;
        }

        private IList<KitViewModel> ObterKit()
        {
            var dados = kitAppService.ObterTodos().ToList();
            var kit = new KitViewModel
            {
                Codigo = 0,
                Descricao = "Selecione Kit"
            };
            dados.Insert(0, kit);
            return dados;
        }

        private SelectList ObterKitParaCombo()
        {
            var dados = ObterKit();
            var dadosSelect = new SelectList(dados, "Codigo", "Descricao");

            return dadosSelect;
        }

        #endregion

    }
}