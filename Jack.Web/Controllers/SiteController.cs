using System.Collections.Generic;
using System.Web.Mvc;
using Jack.Library;

namespace Jack.Web.Controllers
{

    public class SiteController : BaseController
    {

        #region Public Methods

        public ActionResult TituloEBreadCrumb()
        {
            var breadCrumb = (BreadCrumbETitulo)this.TempData["BreadCrumETitulo"]
                             ?? new BreadCrumbETitulo { Titulo = "Não definido", BreadCrumbs = new List<BreadCrumb>() };

            return this.PartialView(breadCrumb);
        }


        public ActionResult MenuTopo()
        {
            return PartialView("_TopNavBar2");
        }

        public ActionResult MenuLateral()
        {
            return PartialView("_Navigation");
        }

        [AllowAnonymous]
        public ActionResult Alertar()
        {
            var avisoExibicao = (Aviso)this.TempData["Aviso"];

            if (avisoExibicao == null)
                return PartialView(avisoExibicao);

            switch (avisoExibicao.TipoMensagem)
            {
                case Aviso.Tipo.Atencao:
                    ViewBag.TipoAlerta = "alert-warning";
                    ViewBag.Icone = "icone-exclamacao";
                    break;

                case Aviso.Tipo.Erro:
                    ViewBag.TipoAlerta = "alert-danger";
                    ViewBag.Icone = "icone-exclamacao";
                    break;

                case Aviso.Tipo.Informacao:
                    ViewBag.TipoAlerta = "alert-info";
                    ViewBag.Icone = "";
                    break;

                case Aviso.Tipo.Sucesso:
                    ViewBag.TipoAlerta = "alert-success";
                    ViewBag.Icone = "";
                    break;

            }

            return this.PartialView(avisoExibicao);
        }


        #endregion
    }
}