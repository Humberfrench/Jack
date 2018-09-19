using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Relatorios")]
    public class RelatoriosController : BaseController
    {
        private readonly ISacolaServiceApp sacolaAppService;
        private readonly INivelServiceApp nivelAppService;
        private readonly IKitServiceApp kitAppService;
        private readonly IColaboradorServiceApp colaboradorAppService;

        public RelatoriosController(ISacolaServiceApp sacolaAppService,
                                    IKitServiceApp kitAppService,
                                    IColaboradorServiceApp colaboradorAppService,
                                    INivelServiceApp nivelAppService)
        {
            this.sacolaAppService = sacolaAppService;
            this.nivelAppService = nivelAppService;
            this.kitAppService = kitAppService;
            this.colaboradorAppService = colaboradorAppService;
        }

        #region Métodos Públicos
        [Route("SacolasLivres")]
        public ActionResult SacolasLivres()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Relatorios Sacolas Livres",
                BreadCrumbs = new List<BreadCrumb>
                {
                    new BreadCrumb {LinkText = "Sacolas Livres", ActionName = "SacolasLivres", ControllerName = "Relatorios"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Nivel = ObterNivelParaCombo();
            ViewBag.Kit = ObterKitParaCombo();
            return View();
        }
        ///Relatorios/SacolasLivres/2017/Liberado/1/Nivel/0/Kit/0
        [Route("SacolasLivres/{ano}/Liberado/{liberado}/Nivel/{nivel}/Kit/{kit}")]
        public ActionResult SacolasLivres(int ano, int liberado, int nivel, int kit)
        {
            var sacolas = sacolaAppService.ObterSacolasLivres(ano, liberado, nivel, kit);

            return View("SacolasLivresLista", sacolas);
        }

        [Route("SacolasColaborador")]
        public ActionResult SacolasColaborador()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Relatorios Sacolas Livres",
                BreadCrumbs = new List<BreadCrumb>
                {
                    new BreadCrumb {LinkText = "Sacolas Livres", ActionName = "SacolasLivres", ControllerName = "Relatorios"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Colaborador = ObterColaboradorParaCombo();
            return View("SacolasLivresLista");
        }

        [Route("SacolasColaborador/{colaborador}/{ano}")]
        public ActionResult SacolasColaborador(int ano, int colaborador)
        {

            var listaDados = colaboradorAppService.ObterSacolasColaborador(colaborador, ano);
            return View(listaDados);

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

        #endregion

    }
}