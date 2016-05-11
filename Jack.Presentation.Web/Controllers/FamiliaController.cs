using Jack.Presentation.Web.Controllers.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Jack.Application;
using Model = Jack.Model;
using System.Net;
using Jack.DTO;

namespace Controllers.MVC
{
	public class FamiliaController : BaseController
    {

		// GET: Familia
		public ActionResult Index()
		{
            HttpStatusCode httpStatus;

            var listaFamilias = GetApiMethod<List<DTOFamilia>>("/Familias", null, out httpStatus);

            return View(listaFamilias);

		}

	}
}
