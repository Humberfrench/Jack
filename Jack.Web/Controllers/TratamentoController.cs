using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Tratamento")]
    public class TratamentoController : Controller
    {
        ITratamentoServiceApp tratamentoServiceApp;
        IFamiliaServiceApp familiaAppService;
        IStatusTratamentoServiceApp statusTratamentoServiceApp;
        ITipoDeProblemaServiceApp tipoDeProblemaServiceApp;

        public TratamentoController(ITratamentoServiceApp tratamentoServiceApp,
                                    IFamiliaServiceApp familiaAppService,
                                    IStatusTratamentoServiceApp statusTratamentoServiceApp,
                                    ITipoDeProblemaServiceApp tipoDeProblemaServiceApp)
        {
            this.familiaAppService = familiaAppService;
            this.tratamentoServiceApp = tratamentoServiceApp;
            this.statusTratamentoServiceApp = statusTratamentoServiceApp;
            this.tipoDeProblemaServiceApp = tipoDeProblemaServiceApp;
        }


        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Tratamento",
                BreadCrumbs = new List<BreadCrumb>
                {
                    new BreadCrumb {LinkText = "Tratamento", ActionName = nameof(Index), ControllerName = "Tratamento"},
                    new BreadCrumb {LinkText = nameof(Detalhe), ActionName = nameof(Detalhe), ControllerName = "Tratamento"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var tratamentos = new List<TratamentoViewModel>();
            ViewBag.Familia = ObterFamiliaParaCombo();

            return View(tratamentos);
        }

        [Route("{familiaId}")]
        public ActionResult Index(int familiaId)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Tratamento",
                BreadCrumbs = new List<BreadCrumb>
                {
                    new BreadCrumb {LinkText = "Tratamento", ActionName = nameof(Index), ControllerName = "Tratamento"},
                    new BreadCrumb {LinkText = nameof(Detalhe), ActionName = nameof(Detalhe), ControllerName = "Tratamento"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var tratamentos = tratamentoServiceApp.ObterTodos(familiaId);
            ViewBag.Familia = ObterFamiliaParaCombo();
            return View(tratamentos);
        }

        [Route("Detalhe/{id}")]
        public ActionResult Detalhe(int id)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Tratamento",
                BreadCrumbs = new List<BreadCrumb>
                {
                    new BreadCrumb {LinkText = "Tratamento", ActionName = nameof(Index), ControllerName = "Tratamento"},
                    new BreadCrumb {LinkText = nameof(Detalhe), ActionName = nameof(Detalhe), ControllerName = "Tratamento"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Status = ObterStatusParaCombo();
            ViewBag.Familia = ObterFamiliaParaCombo();
            ViewBag.TipoDeProblema = ObterTipoDeProblemaParaCombo();

            var dados = tratamentoServiceApp.ObterPorId(id);

            if (dados == null)
            {
                dados = new TratamentoViewModel();
            }

            return View(dados);
        }

        #region Private

        private IList<FamiliaViewModel> ObterFamilia()
        {
            var dados = familiaAppService.ObterTodosTratamento().OrderBy(c => c.Nome).ToList();
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


        private IList<StatusTratamentoViewModel> ObterStatus()
        {
            var dados = statusTratamentoServiceApp.ObterTodos().OrderBy(c => c.Descricao).ToList();
            var familia = new StatusTratamentoViewModel
            {
                StatusTratamentoId = 0,
                Descricao = "Selecione Status do Tratamento"
            };
            dados.Insert(0, familia);

            return dados;
        }

        private SelectList ObterStatusParaCombo()
        {
            var dados = ObterStatus();
            var dadosSelect = new SelectList(dados, "StatusTratamentoId", "Descricao");

            return dadosSelect;
        }


        private IList<TipoDeProblemaViewModel> ObterTipoDeProblema()
        {
            var dados = tipoDeProblemaServiceApp.ObterTodos().OrderBy(c => c.Descricao).ToList();
            var familia = new TipoDeProblemaViewModel
            {
                TipoDeProblemaId = 0,
                Descricao = "Selecione Tipo De Problema"
            };
            dados.Insert(0, familia);

            return dados;
        }

        private SelectList ObterTipoDeProblemaParaCombo()
        {
            var dados = ObterTipoDeProblema();
            var dadosSelect = new SelectList(dados, "TipoDeProblemaId", "Descricao");

            return dadosSelect;
        }


        #endregion

    }
}