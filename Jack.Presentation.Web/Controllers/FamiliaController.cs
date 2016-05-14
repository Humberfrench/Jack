using Jack.DTO;
using Jack.Presentation.Web.Controllers.MVC;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Controllers.MVC
{
    public class FamiliaController : BaseController
    {

		// GET: Familia
		public ActionResult Index()
		{
            HttpStatusCode httpStatus;

            var listaFamilias = GetApiMethod<List<DTOFamilia>>("/Familia", null, out httpStatus);

            return View(listaFamilias);

		}

	}
}