using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Application = Jack.Application;
using Model = Jack.Model;

namespace Controllers.MVC
{
    public class SacolasController : Controller
	{

		// GET: Sacolas
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Livres()
		{
			return View();
		}

	}
}

