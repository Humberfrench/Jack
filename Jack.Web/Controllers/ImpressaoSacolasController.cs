using Jack.Application.Interfaces;
using Jack.Library;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Impressao/Sacolas")]
    public class ImpressaoSacolasController : BaseController
    {
        #region Vars

        private readonly ISacolaServiceApp sacolaAppService;
        private readonly INivelServiceApp nivelAppService;
        private readonly ICriancaServiceApp criancaAppService;
        private readonly IFamiliaServiceApp familiaAppService;

        #endregion

        #region Ctor

        public ImpressaoSacolasController(ICriancaServiceApp criancaAppService,
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

        [Route("QrCode")]
        public ActionResult QrCode()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Consulta de Sacolas",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Teste de Qr Code", ActionName = "QrCode", ControllerName = "Sacolas"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            var listaDados = sacolaAppService.ObterTodos();
            return View();
        }

        [Route("GerarQrCode")]
        [HttpPost]
        public ActionResult GerarQrCode(int width, int height, int crianca)
        {
            var tipo = sacolaAppService.GerarQrCode(width, height, crianca);

            byte[] imgBytes = (byte[])tipo;
            string base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);

            return Json(base64String, JsonRequestBehavior.AllowGet);
        }

        [Route("Modelo")]
        public ActionResult Modelo()
        {
            return View();

        }
    }
}