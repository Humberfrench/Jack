using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.DomainValidator;
using Jack.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Familia")]
    public class FamiliaController : BaseController
    {
        #region Vars

        private readonly IFamiliaServiceApp familiaAppService;
        private readonly ICriancaServiceApp criancaAppService;
        private readonly INivelServiceApp nivelAppService;
        private readonly IStatusFamiliaServiceApp statusAppService;
        private readonly IReuniaoServiceApp reuniaoAppService;
        private readonly IParametroServiceApp parametroAppService;

        #endregion

        #region Ctor

        public FamiliaController(IFamiliaServiceApp familiaAppService,
                                 ICriancaServiceApp criancaAppService,
                                 IStatusFamiliaServiceApp statusAppService,
                                 IParametroServiceApp parametroAppService,
                                 INivelServiceApp nivelAppService,
                                 IReuniaoServiceApp reuniaoAppService)
        {
            this.familiaAppService = familiaAppService;
            this.criancaAppService = criancaAppService;
            this.statusAppService = statusAppService;
            this.parametroAppService = parametroAppService;
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
                 new BreadCrumb {LinkText = "Família", ActionName = nameof(Index), ControllerName = "Familia"},
                 new BreadCrumb {LinkText = "Lista", ActionName = nameof(Index), ControllerName = "Familia"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterStatusParaCombo();
            ViewBag.Nivel = ObterNivelParaCombo();
            ViewBag.Reuniao = ObterReuniaoParaCombo();



            var listaDados = familiaAppService.ObterTodos().OrderBy(c => c.Nome);
            var familias = listaDados.Select(f => f.Nome);

            ViewBag.FamiliasAutoComplete = string.Join(",", familias);

            return View(listaDados);
        }

        [HttpGet]
        [Route("Todas")]
        public ActionResult TodasFamilias()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Família",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Família", ActionName = nameof(TodasFamilias), ControllerName = "Familia"},
                 new BreadCrumb {LinkText = "Lista", ActionName = nameof(TodasFamilias), ControllerName = "Familia"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterStatusParaCombo();
            ViewBag.Nivel = ObterNivelParaCombo();
            ViewBag.Reuniao = ObterReuniaoParaCombo();
            var parametro = parametroAppService.Obter();

            ViewBag.NumeroMaximoCricancas = parametro.NumeroMaximoCricancas;
            ViewBag.NumeroMaximoRepresentantes = parametro.NumeroMaximoRepresentantes;

            var listaDados = familiaAppService.ObterTodos().OrderBy(c => c.Nome);
            return View(listaDados);
        }

        [HttpGet]
        [Route("FiltroTodas")]
        public ActionResult FiltroTodasFamilias(string nome = "")
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Família",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Família", ActionName = nameof(TodasFamilias), ControllerName = "Familia"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = nameof(TodasFamilias), ControllerName = "Familia"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterStatusParaCombo();
            ViewBag.Nivel = ObterNivelParaCombo();
            ViewBag.Reuniao = ObterReuniaoParaCombo();
            var parametro = parametroAppService.Obter();

            ViewBag.NumeroMaximoCricancas = parametro.NumeroMaximoCricancas;
            ViewBag.NumeroMaximoRepresentantes = parametro.NumeroMaximoRepresentantes;

            var listaDados = familiaAppService.Filtrar(nome).OrderBy(c => c.Nome);
            return View(nameof(TodasFamilias), listaDados);
        }


        [HttpGet]
        [Route("Banidas")]
        public ActionResult FamiliasBanidas()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Família",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Famílias Banidas", ActionName = nameof(FamiliasBanidas), ControllerName = "Familia"},
                 new BreadCrumb {LinkText = "Lista", ActionName = nameof(FamiliasBanidas), ControllerName = "Familia"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var parametro = parametroAppService.Obter();

            ViewBag.NumeroMaximoCricancas = parametro.NumeroMaximoCricancas;
            ViewBag.NumeroMaximoRepresentantes = parametro.NumeroMaximoRepresentantes;

            var listaDados = familiaAppService.ObterFamiliasBanidas().OrderBy(c => c.Nome);
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
                 new BreadCrumb {LinkText = "Família", ActionName = nameof(Index), ControllerName = "Familia"},
                 new BreadCrumb {LinkText = "Filtro", ActionName = "Filtro", ControllerName = "Familia"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterStatusParaCombo();
            ViewBag.Nivel = ObterNivelParaCombo();
            ViewBag.Reuniao = ObterReuniaoParaCombo();

            var listaDados = familiaAppService.Filtrar(nome).OrderBy(c => c.Nome);
            return View(nameof(Index), listaDados);
        }

        [Route(nameof(Edit))]
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
        [Route(nameof(Gravar))]
        public ActionResult Gravar(FamiliaViewModel familia, int reuniao)
        {
            ValidationResult gravarResult;

            if (reuniao == 0)
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

        [Route(nameof(Excluir))]
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
        [HttpPost, Route(nameof(Liberar))]
        public ActionResult Liberar(int id)
        {
            var liberarResult = familiaAppService.LiberarFamiliaBanida(id);

            object retorno;
            if (liberarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Família Liberada com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(liberarResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, Route(nameof(Bloquear))]
        public ActionResult Bloquear(int id)
        {
            var liberarResult = familiaAppService.AtualizarFamiliaParaBanida(id);

            object retorno;
            if (liberarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Família Bloqueada/Banida com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(liberarResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [Route(nameof(Processar))]
        public ActionResult Processar(int id)
        {
            var processarResult = familiaAppService.AtualizarFamilia(id);

            object retorno;
            if (processarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Família Atualizada com Sucesso",
                    Erro = false,
                    Warning = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(processarResult),
                    Erro = true,
                    Warning = processarResult.Warning
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [Route(nameof(ProcessarCriancas))]
        public ActionResult ProcessarCriancas(int id)
        {
            var processarResult = criancaAppService.AtualizaCriancas(id);

            object retorno;
            if (processarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Família Atualizada com Sucesso",
                    Erro = false,
                    Warning = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(processarResult),
                    Erro = true,
                    Warning = processarResult.Warning
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [Route(nameof(ProcessarPresenca))]
        public ActionResult ProcessarPresenca(int id)
        {
            var processarResult = familiaAppService.AtualizarFamiliaComPresencaParaRepresentantes(id,true);

            object retorno;
            if (processarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Família Atualizada com Sucesso",
                    Erro = false,
                    Warning = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(processarResult),
                    Erro = true,
                    Warning = processarResult.Warning
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
        [Route(nameof(ObterRepresentantes))]
        public ActionResult ObterRepresentantes(int codigo)
        {
            var familia = familiaAppService.ObterPorId(codigo);
            return View("Representantes", familia.Representantes);
        }

        [Route(nameof(ObterCriancas))]
        public ActionResult ObterCriancas(int codigo)
        {
            var familia = familiaAppService.ObterPorId(codigo);
            return View("Criancas", familia.Criancas);
        }

        [Route(nameof(ObterPresencas))]
        public ActionResult ObterPresencas(int codigo)
        {
            var familia = familiaAppService.ObterPorId(codigo);
            return View("Presencas", familia.Presencas.Where(p => p.Reuniao.AnoCorrente == DateTime.Now.Year).ToList());
        }

        [Route("PorStatus")]
        public ActionResult ConsultaPorStatus()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Família",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Família", ActionName = nameof(Index), ControllerName = "Familia"},
                 new BreadCrumb {LinkText = "Obter Por Status", ActionName = nameof(Index), ControllerName = nameof(ConsultaPorStatus)}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterStatusParaCombo();
            return View(nameof(ConsultaPorStatus), new List<FamiliaViewModel>());
        }

        [Route("PorStatus/{status}")]
        public ActionResult ConsultaPorStatus(int status)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Família",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Família", ActionName = nameof(Index), ControllerName = "Familia"},
                 new BreadCrumb {LinkText = "Obter Por Status", ActionName = nameof(Index), ControllerName = nameof(ConsultaPorStatus)}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterStatusParaCombo();
            var familia = familiaAppService.ObterPorStatus(status);
            return View(nameof(ConsultaPorStatus), familia.ToList());
        }

        [Route("NaoSacolas")]
        public ActionResult ObterFamiliasNaoSacolas()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Família",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Família", ActionName = nameof(Index), ControllerName = "Familia"},
                 new BreadCrumb {LinkText = "Obter Familias Sem Sacolas", ActionName = nameof(Index), ControllerName = nameof(ObterFamiliasNaoSacolas)}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var familia = familiaAppService.ObterNaoSacolas();
            return View(nameof(ObterFamiliasNaoSacolas), familia.ToList());
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