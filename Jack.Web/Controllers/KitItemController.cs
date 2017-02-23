using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Kit/Item")]
    public class KitItemController : BaseController
    {
        #region Vars

        private readonly IKitServiceApp kitAppService;
        private readonly IKitItemServiceApp kitItemAppService;
        private readonly ITipoItemServiceApp tipoItemAppService;

        #endregion

        #region Ctor

        public KitItemController(IKitServiceApp kitAppService,
                                 IKitItemServiceApp kitItemAppService,
                                 ITipoItemServiceApp tipoItemAppService)
        {
            this.kitAppService = kitAppService;
            this.kitItemAppService = kitItemAppService;
            this.tipoItemAppService = tipoItemAppService;
        }

        #endregion

        #region Public Methods
        [Route("{id}")]
        public ActionResult Index(int id)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Kits",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Kits", ActionName = "Index", ControllerName = "Kit"},
                 new BreadCrumb {LinkText = "Itens de Kit", ActionName = "Index", ControllerName = "KitItem"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var kit = kitAppService.ObterPorId(id);
            string sexo = "";
            switch (kit.Sexo)
            {
                case "M": sexo = "Menino"; break;
                case "F": sexo = "Menina"; break;
                default: sexo = "Indefinido"; break;
            }
            ViewBag.CodigoKit = kit.Codigo;
            ViewBag.DescricaoKit = kit.Descricao;
            ViewBag.IdadeMinimaKit = kit.IdadeMinima;
            ViewBag.IdadeMaximaKit = kit.IdadeMaxima;
            ViewBag.SexoKit = sexo;
            ViewBag.NecessicadeEspecialKit = kit.NecessidadeEspecial;
            ViewBag.TipoItem = ObterTipoItemCombo();
            var listaDados = kitItemAppService.ObterTodos(id).OrderBy(k => k.Ordem);

            return View(listaDados);
        
        }

        [Route("Ver/{id}")]
        public ActionResult Itens(int id)
        {
            var kit = kitAppService.ObterPorId(id);
            string sexo = "";
            switch (kit.Sexo)
            {
                case "M": sexo = "Menino"; break;
                case "F": sexo = "Menina"; break;
                default: sexo = "Indefinido"; break;
            }
            ViewBag.CodigoKit = kit.Codigo;
            ViewBag.DescricaoKit = kit.Descricao;
            ViewBag.IdadeMinimaKit = kit.IdadeMinima;
            ViewBag.IdadeMaximaKit = kit.IdadeMaxima;
            ViewBag.SexoKit = sexo;
            ViewBag.NecessicadeEspecialKit = kit.NecessidadeEspecial;
            var listaDados = kitItemAppService.ObterTodos(id).OrderBy(k => k.Ordem);

            return View(listaDados);
        
        }
 
        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var kitItem = kitItemAppService.ObterPorId(id);
            kitItem.Kit.Criancas.Clear();
            kitItem.Kit.Items.Clear();
            
            return Json(kitItem, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        [Route("Gravar")]
        public ActionResult Gravar(KitItemViewModel kitItem)
        {
            var gravarResult = kitItemAppService.Gravar(kitItem);
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
            var excluirResult = kitItemAppService.Excluir(id);

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
        private IList<TipoItemViewModel> ObterTipoItem()
        {
            var lista = tipoItemAppService.ObterTodos().ToList();
            return lista;
        }

        private SelectList ObterTipoItemCombo()
        {
            var lista = ObterTipoItem();
            var listaSelect = new SelectList(lista, "Codigo", "Descricao");

            return listaSelect;
        }


        #endregion
    }
}