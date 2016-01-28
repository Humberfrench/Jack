using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Business = Jack.Business;
using Model = Jack.Model;


namespace Controllers.MVC
{
	public class FamiliaCriancaController : Controller
	{

		// GET: FamiliaCrianca
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Representante()
		{
			return View();
		}

	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
