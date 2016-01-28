using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Business = Jack.Business;
using Model = Jack.Model;


namespace Controllers.MVC
{
	public class CalcadosController : Controller
	{

		// GET: Calcados
		public ActionResult Index()
		{

			Business.Calcado CalcadoBusiness = null;
			List<Model.Calcado> CalcadoRetorno = null;


			try {
				CalcadoBusiness = new Business.Calcado();
				CalcadoRetorno = CalcadoBusiness.LoadAll();

			} catch (Exception ex) {
				CalcadoRetorno = new List<Model.Calcado>();
			} finally {
				CalcadoBusiness = null;
			}

			return View(CalcadoRetorno);

		}

		public ActionResult Meninos()
		{

			Business.Calcado CalcadoBusiness = null;
			List<Model.Calcado> CalcadoRetorno = null;


			try {
				CalcadoBusiness = new Business.Calcado();
				CalcadoRetorno = CalcadoBusiness.LoadAll().Where(x => x.Sexo == "M").ToList();

			} catch (Exception ex) {
				CalcadoRetorno = new List<Model.Calcado>();
			} finally {
				CalcadoBusiness = null;
			}

			return View(CalcadoRetorno);

		}

		public ActionResult Meninas()
		{

			Business.Calcado CalcadoBusiness = null;
			List<Model.Calcado> CalcadoRetorno = null;


			try {
				CalcadoBusiness = new Business.Calcado();
				CalcadoRetorno = CalcadoBusiness.LoadAll().Where(x => x.Sexo == "F").ToList();

			} catch (Exception ex) {
				CalcadoRetorno = new List<Model.Calcado>();
			} finally {
				CalcadoBusiness = null;
			}

			return View(CalcadoRetorno);

		}

	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
